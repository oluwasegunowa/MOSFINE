﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Flurl.Http;
using Mosfin.Clients.Common.Contracts.Device;
using Mosfin.Clients.Common.Contracts.Utils;
using Mosfin.Clients.Common.Logics;
using Mosfin.Clients.Common.Utils;
using Mosfin.DataObjects.Models;
using Newtonsoft.Json;

namespace Mosfin.Clients.Common.Services
{
	public static class DIFactory
	{
		public static IContainer Container { get; set; }
		public static bool ReIssueTokenOnError = true;

		public static void Initialize()
		{
			var builder = new ContainerBuilder();


            #if DEBUG

		   // builder.RegisterInstance(new Alat.BackendEngine.Mock.ImageEngine()).As<IImageEngine>();
			#else
           //builder.RegisterInstance(new ImageEngine()).As<IImageEngine>();
            #endif


			/*
             * Registering Repositories
             */

			//builder.RegisterInstance(new AccountRepository()).As<IAccountRepository>();

			// Registering Services
			//builder.RegisterType<UserSessionManager>();
			


			DIFactory.Container = builder.Build();

			FlurlHttp.Configure(c =>
			{
				c.OnError += (HttpCall obj) =>
				{
					var status = obj.HttpStatus;
				};

				c.BeforeCall += (HttpCall obj) =>
				{
                    var clientKeyProvider = DIFactory.Resolve<IClientKeyProvider>();
					obj.Request.Headers.Remove("mosfin-token");
					obj.Request.Headers.Remove("Authorization");
					obj.Request.Headers.Remove("mosfin-client-apikey");
					


					obj.Request.Headers.Add("mosfin-client-apikey", clientKeyProvider.GetClientKey());

					var urlPath = obj.Request.RequestUri.AbsolutePath;

					if (!Configs.LOGIN_URL.EndsWith(urlPath, StringComparison.CurrentCultureIgnoreCase)
						|| !Configs.LOGIN_WITH_BIOMETRICS_URL.EndsWith(urlPath, StringComparison.CurrentCultureIgnoreCase))
					{
						var keyValueStore = DIFactory.Resolve<IKeyValueStore>();
						string serializedUser = keyValueStore.Get(Constants.Session.LOGGED_IN_USER);
						if (!String.IsNullOrEmpty(serializedUser))
						{
							var token = JsonConvert.DeserializeObject<DeviceUser>(serializedUser).Token;

							obj.Request.Headers.Add("mosfin-token", token);
							obj.Request.Headers.Add("Authorization", "Bearer");
						}
					}
				};


				c.AfterCall += (HttpCall obj) =>
				{
					var urlPath = obj.Request.RequestUri.AbsolutePath;
					var userSessionManager = DIFactory.Resolve<UserSessionLogic>();
					

                    if (obj.HttpStatus == System.Net.HttpStatusCode.Unauthorized
						&& !Configs.SEND_NOTIFICATION_TOKEN_URL.EndsWith(urlPath, StringComparison.CurrentCultureIgnoreCase))
					{
						userSessionManager.LogoutUser();
					}


					if (Configs.REISSUE_TOKEN_URL.EndsWith(urlPath, StringComparison.CurrentCultureIgnoreCase))
					{
						var statuses = new System.Net.HttpStatusCode[] { System.Net.HttpStatusCode.OK,
							System.Net.HttpStatusCode.Unauthorized, System.Net.HttpStatusCode.Forbidden };
						if (!statuses.Any((arg) => arg == obj.HttpStatus))
						{
							if (!Globals.IsSessionTimedOut())
							{
								Task.Run(async delegate
								{
									if (ReIssueTokenOnError)
									{
										ReIssueTokenOnError = false;
										await Task.Delay(30 * 1000);
										var keyValueStore = DIFactory.Resolve<IKeyValueStore>();
										string serializedUser = keyValueStore.Get(Constants.Session.LOGGED_IN_USER);
										if (serializedUser != null)
										{
											await userSessionManager.ReIssueToken();
										}
									}
								});
							}
							else
							{
								userSessionManager.LogoutUser();
							}
						}
					}


					if (obj.HttpStatus == System.Net.HttpStatusCode.OK)
					{

						if ((Configs.LOGIN_URL.EndsWith(urlPath, StringComparison.CurrentCultureIgnoreCase))
							|| (Configs.LOGIN_WITH_BIOMETRICS_URL.EndsWith(urlPath, StringComparison.CurrentCultureIgnoreCase))
							|| (Configs.REISSUE_TOKEN_URL.EndsWith(urlPath, StringComparison.CurrentCultureIgnoreCase)
								&& userSessionManager.IsUserLoggedIn()))
						{
							if (!Globals.IsSessionTimedOut())
							{
								Task.Run(async delegate
								{
									await Task.Delay(2 * 60 * 1000);
									ReIssueTokenOnError = true;

									await userSessionManager.ReIssueToken();

								});
							}
							else
							{
								//userSessionManager.LogoutUser();
							}
						}
					}
				};
			});
		}

		public static T Resolve<T>()
		{

			return DIFactory.Container.Resolve<T>();
		}
	}
}
