using System;
namespace Mosfin.Clients.Common.Contracts.Device
{
    public interface ISecureStorageUtil
    {
        string GetClientKey();
        string UserName { get; }
        string Password { get; }
        string SessionToken { get; }
        string BiometricToken { get; }
        void SaveCredentials(string userName, string password, string sessionToken, string biometricToken, string deviceToken);
        void DeleteCredentials();
    }
}
