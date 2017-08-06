using System;
using System.Threading.Tasks;
using Flurl.Http;
using Mosfin.BackendEnine.Service.Implementation;
using Mosfin.Clients.Common.Contracts.Utils;
using Mosfin.Clients.Common.Logic;
using Mosfin.Clients.Common.Utils;
using Mosfin.DataObjects.DataObjects;
using Mosfin.DataObjects.Models;

namespace Mosfin.Clients.Common.Logics
{
    public class AuthenticationLogic:BaseLogic
    {

        UserSessionLogic _sessionoLogic;
        IAuthenticationClient _authenticationClient;
        DatabaseLogic _dbLogic;

        public AuthenticationLogic()
        {
        }



		public async Task LogIn(string userName, string password,
							string deviceName, string deviceOs, string gcmRegId,
                                string deviceCode, Action<NetworkErrorModel> onError=null,
							Action<LoginDO> onSuccess = null)
		{

			try
			{
				var loginModel = new LoginDO
				{
					Email = userName,
					Password = password
                     
					
				};

				//DeviceCode = deviceCode,
                    //ChannelId = Configs.CHANNEL_ID,
                    //DeviceName = deviceName,
                    //DeviceOS = deviceOs,
                    //GCMId = gcmRegId,
                    //ApplicationVersion = "",
				_sessionoLogic.ClearUserLoginSession();
				var loginResponse = await _authenticationClient.LogIn(loginModel);


                _sessionoLogic.CreateUserLoginSession(loginResponse);

				if (_sessionoLogic.IsUserLoggedIn() && !_sessionoLogic.LoggedInUser.IsDeviceVerified)
				{
					
					Globals.UpdateActivityEpoch();
                    if (null != onSuccess)
                    {
                        onSuccess(loginResponse);
                    }
					return;
				}
			   _dbLogic.PerformDatabaseInitialization();

  
                _sessionoLogic. PersistUserLoginInfo(userName);
				Globals.UpdateActivityEpoch();
				if (null != onSuccess)
					onSuccess(loginResponse);
			}
			catch (FlurlHttpException ex)
			{
				HandleHttpError(onError, ex);
			}
			catch (ArgumentException ex)
			{
				var ss = ex.ToString();
				//HandleHttpError(onError, new FlurlHttpException(){ });
			}
			catch (Exception ex)
			{
				var sds = ex.ToString();
				//HandleHttpError(onError);
			}
		}


		public async Task InitiateForgotPassword(string email, Action<ForgotPasswordDO> onSuccess = null, Action<NetworkErrorModel> onError = null)
		{
			try
			{
				var payload = new ForgotPasswordDO
				{
					Email = email
				};

                var loginResponse = await _authenticationClient.ValidateEmailAddressForForgotPassword(payload);
				onSuccess(loginResponse);
			}
			catch (FlurlHttpException ex)
			{
				HandleHttpError(onError, ex);
			}
        }


        public async Task VerifySecurityAnswer(string email, long securityQuestionId, string securityAnswer, Action<SecurityQuestionValidationDO> onSuccess = null, Action<NetworkErrorModel> onError = null)
		{
			try
			{
				var payload = new SecurityQuestionValidationDO
				{
					SecurityQuestionId = securityQuestionId,
					Email = email,
					Answer = securityAnswer

				};

                var loginResponse = await _authenticationClient.ValidateSecurityQuestion(payload);
				onSuccess(loginResponse);
			}
			catch (FlurlHttpException ex)
			{
				HandleHttpError(onError, ex);
			}
		}


	}
}
