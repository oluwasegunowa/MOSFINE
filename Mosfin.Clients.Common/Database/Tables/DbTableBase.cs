using System;
using SQLite;

namespace Mosfin.Clients.Common.Database
{
	public class DbTableBase
	{
		public DbTableBase()
		{
		}
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
	}
}
