using System;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using Mosfin.DataObjects.Models;

namespace Mosfin.Clients.Common.Logic
{
    public class BaseLogic
    {
        public BaseLogic()
        {
        }

		public void HandleHttpError(Action<NetworkErrorModel> onError, FlurlHttpException ex)
		{
			if (onError != null)
			{
				NetworkErrorModel networkModel = new NetworkErrorModel();
				try
				{
					if (ex.InnerException?.GetType() == typeof(TaskCanceledException))
					{
						networkModel.Message = "We can't complete this action because there was a timeout.";
						onError(networkModel);
					}
					else if (ex.Call.Response == null)
					{
						networkModel.Message = "You are offline, please check your internet connection";
						onError(networkModel);
					}
					else if (ex.Call.Response.StatusCode == System.Net.HttpStatusCode.BadRequest)
					{
						onError(ex.GetResponseJson<NetworkErrorModel>());
					}
					else if (ex.Call.Response.StatusCode == System.Net.HttpStatusCode.Forbidden)
					{
						networkModel.Message = "Oops. You are not permitted to access this resource.";
						onError(networkModel);
					}
					else if (ex.Call.Response.StatusCode == System.Net.HttpStatusCode.GatewayTimeout)
					{
						networkModel.Message = "This resource is on a very old slow server with 10kb connection.";
						onError(networkModel);
					}
					else if (ex.Call.Response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
					{

						networkModel.Message = "Oops. Something went wrong. Please try again.";
						onError(networkModel);
					}
					else if (ex.Call.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
					{
						networkModel.Message = "We can't find the resource you are looking for.";
						onError(networkModel);
					}
					else if (ex.Call.Response.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable)
					{
						networkModel.Message = "We are sorry. The server is currently unavailable. Please try again later.";
						onError(networkModel);
					}

					else
					{
						try
						{
							onError(ex.GetResponseJson<NetworkErrorModel>());
						}
						catch
						{
							networkModel.Message = ex.GetResponseString();
							onError(networkModel);
						}
					}
				}
				catch
				{
					networkModel.Message = "Oops. Something went wrong. Please try again.";
					onError(networkModel);
				}

			}
		}

		public void HandleHttpError(Action<NetworkErrorModel> onError, HttpRequestException ex)
		{
			if (onError != null)
			{
				NetworkErrorModel networkModel = new NetworkErrorModel() { Message = ex.Message };
				onError(networkModel);
			}
		}

        public void HandleHttpError(Action<NetworkErrorModel> onError, Exception ex)
		{
			if (onError != null)
			{
				NetworkErrorModel networkModel = new NetworkErrorModel() { Message = ex.Message };
				onError(networkModel);
			}
		}
    }
}
