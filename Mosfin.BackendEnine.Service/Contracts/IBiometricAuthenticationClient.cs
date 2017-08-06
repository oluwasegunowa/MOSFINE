using System;
using System.Threading.Tasks;
using Mosfin.DataObjects.DataObjects;

namespace Mosfin.BackendEnine.Service.Contracts
{
    public interface IBiometricAuthenticationClient
    {
        Task<BiometricLoginDO> ActivateBiometrics(BiometricLoginDO loginModel, ApplicationInfoDO info);
        Task<BiometricLoginDO> DeactivateBiometrics(BiometricLoginDO loginModel, ApplicationInfoDO info);
        Task<BiometricLoginDO> BiometricsAuthentication(BiometricLoginDO loginModel, ApplicationInfoDO localPolicy);
    }
}
