using System;
namespace Mosfin.Clients.Common.Contracts.Device
{
    public interface IErrorRenderer
    {
		void RenderConnectivityError();
		void RenderNetworkError();
		void RenderApplicationError(string message);
		void RenderValidationErrors(string key, string value);
    }
}
