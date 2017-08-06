using System;
using SQLite;

namespace Mosfin.Clients.Common.Contracts.Device
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}
