using System;
using System.Threading.Tasks;
using Mosfin.DataObjects.DataObjects;

namespace Mosfin.BackendEnine.Service.Implementation
{
    public class AuthenticationClient : BaseClient, IAuthenticationClient
    {
        public Task<LoginDO> LogIn(LoginDO loginModel)
        {
            throw new NotImplementedException();
        }

        public Task<ForgotPasswordDO> ValidateEmailAddressForForgotPassword(ForgotPasswordDO payload)
        {
            throw new NotImplementedException();
        }

        public Task<SecurityQuestionValidationDO> ValidateSecurityQuestion(SecurityQuestionValidationDO payload)
        {
            throw new NotImplementedException();
        }
    }
}
