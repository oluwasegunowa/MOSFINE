using System;
using System.Threading.Tasks;
using Flurl.Http;
using Mosfin.BackendEnine.Service.Contracts;
using Mosfin.BackendEnine.Service.Implementation;
using Mosfin.Clients.Common.Contracts.Utils;
using Mosfin.Clients.Common.Logic;
using Mosfin.Clients.Common.Utils;
using Mosfin.DataObjects.DataObjects;
using Mosfin.DataObjects.Models;

namespace Mosfin.Clients.Common.Logics
{
    public class BiometricAuthenticationLogic: BaseLogic
    {
        IBiometricAuthenticationClient _authenticationClient;
        public BiometricAuthenticationLogic()
        {
        }


		public async Task ActivateBiometrics(string password,
										   ApplicationInfoDO appInfo,
											 Action<NetworkErrorModel> onError,
											 Action<BiometricLoginDO> onSuccess = null)
		{

			try
			{
                var loginModel = new BiometricLoginDO
				{
					
					Password = password, 
					
				};
             
				var loginResponse = await _authenticationClient.ActivateBiometrics(loginModel,appInfo);

				if (null != onSuccess)
					onSuccess(loginResponse);
			}
			catch (FlurlHttpException ex)
			{
				HandleHttpError(onError, ex);
			}
			catch (Exception ex)
			{
				HandleHttpError(onError,ex);
			}
		}

        public async Task DeactivateBiometrics(string userName, string password,
										   ApplicationInfoDO appInfo,
                                             Action<NetworkErrorModel> onError,
                                             Action<BiometricLoginDO> onSuccess = null)
        {

            try
            {
                var loginModel = new BiometricLoginDO
                {
                    Email = userName,
                     Password=password

                };

                var loginResponse = await _authenticationClient.DeactivateBiometrics(loginModel, appInfo);
                if (null != onSuccess)
                    onSuccess(loginModel);
            }
            catch (FlurlHttpException ex)
            {
                HandleHttpError(onError, ex);
            }
            catch (Exception ex)
            {
                HandleHttpError(onError, ex);
            }
        }

		public async Task BiometricsAuthentication(string userName, string token,
                                                   string localPolicy,ApplicationInfoDO appInfo,
											   Action<NetworkErrorModel> onError,
											   Action<BiometricLoginDO> onSuccess = null)
		{

			try
			{
                var loginModel = new BiometricLoginDO
				{
                    Email = userName,
                     Token=token,
                     LocalPolicy=localPolicy
				};

			

				var loginResponse = await _authenticationClient.BiometricsAuthentication(loginModel, appInfo);
				//CreateUserLoginSession(loginResponse);

			
				Globals.UpdateActivityEpoch();

				if (null != onSuccess)
					onSuccess(loginResponse);
			}
			catch (FlurlHttpException ex)
			{
				HandleHttpError(onError, ex);
			}
			catch (Exception ex)
			{
				//HandleHttpError(onError);
			}
		}
    }
}
