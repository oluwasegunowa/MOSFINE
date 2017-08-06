using System;
using System.Threading.Tasks;
using Mosfin.BackendEnine.Service.Contracts;
using Mosfin.DataObjects.DataObjects;

namespace Mosfin.BackendEnine.Service.Implementation
{
    public class BiometricAuthenticationClient : IBiometricAuthenticationClient
    {
        public Task<BiometricLoginDO> ActivateBiometrics(BiometricLoginDO loginModel, ApplicationInfoDO info)
        {
            throw new NotImplementedException();
        }

        public Task<BiometricLoginDO> BiometricsAuthentication(BiometricLoginDO loginModel, ApplicationInfoDO localPolicy)
        {
            throw new NotImplementedException();
        }

        public Task<BiometricLoginDO> DeactivateBiometrics(BiometricLoginDO loginModel, ApplicationInfoDO info)
        {
            throw new NotImplementedException();
        }
    }
}
