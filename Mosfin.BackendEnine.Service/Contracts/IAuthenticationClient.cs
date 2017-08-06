using System.Threading.Tasks;
using Mosfin.DataObjects.DataObjects;

namespace Mosfin.BackendEnine.Service.Implementation
{
    public interface IAuthenticationClient
    {
        Task<LoginDO> LogIn(LoginDO loginModel);
        Task<ForgotPasswordDO> ValidateEmailAddressForForgotPassword(ForgotPasswordDO payload);
        Task<SecurityQuestionValidationDO> ValidateSecurityQuestion(SecurityQuestionValidationDO payload);
    }
}