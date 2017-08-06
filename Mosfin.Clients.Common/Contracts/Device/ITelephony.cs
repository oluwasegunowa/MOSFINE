using System;
namespace Mosfin.Clients.Common.Contracts.Device
{
    public interface ITelephony
    {
		string GetIMEI(Func<object, string> getIMEI, object context);
		bool IsNetworkConnected(Func<object, bool> isConnected, object context);

	}
}
