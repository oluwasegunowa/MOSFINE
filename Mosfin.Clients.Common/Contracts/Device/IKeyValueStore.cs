using System;
namespace Mosfin.Clients.Common.Contracts.Device
{
    public interface IKeyValueStore
    {

		void Set(string key, string value);
		string Get(string key, string defaultValue = "");
		void Remove(string key);
		void Clear();
    }
}
