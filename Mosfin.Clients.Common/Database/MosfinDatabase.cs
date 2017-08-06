using System;
using System.Collections.Generic;
using System.Linq;
using Mosfin.Clients.Common.Contracts.Device;
using Mosfin.Clients.Common.Database.Tables;
using Mosfin.Clients.Common.Services;
using Mosfin.DataObjects;
using SQLite;

namespace Mosfin.Clients.Common.Database
{
    public class MosfinDatabase
    {
		public static object locker = new object();

		public static SQLiteConnection connection;

		/// <summary>
		/// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
		/// if the database doesn't exist, it will create the database and all the tables.
		/// </summary>
		/// <param name='path'>
		/// Path.
		/// </param>
		static  MosfinDatabase()
		{
			connection = DIFactory.Resolve<ISQLite>().GetConnection();
			// create the tables
			connection.CreateTable<StateTable>();
		
		}

		public static IEnumerable<T> GetItems<T>()
			where T : DbTableBase, new()
		{
			lock (MosfinDatabase.locker)
			{
				return (from i in connection.Table<T>() select i).ToList();
			}
		}

		public static int InsertAll<T>(IEnumerable<T> objects)
		where T : DbTableBase, new()
		{
			lock (MosfinDatabase.locker)
			{
				return connection.InsertAll(objects);
			}
		}

		public static int UpdateAll<T>(IEnumerable<T> objects)
			where T : DbTableBase, new()
		{
			lock (MosfinDatabase.locker)
			{
				return connection.UpdateAll(objects);
			}
		}
		public static T GetItem<T>(int id)
		where T : DbTableBase, new()
		{
			lock (MosfinDatabase.locker)
			{
				return MosfinDatabase.connection.Table<T>().FirstOrDefault(x => x.Id == id);
			}
		}

		public static int SaveItem<T>(T item)
		where T : DbTableBase, new()
		{
			lock (MosfinDatabase.locker)
			{
				if (item.Id != 0)
				{
					MosfinDatabase.connection.Update(item);
					return item.Id;
				}
				else
				{
					return MosfinDatabase.connection.Insert(item);
				}
			}
		}
		public static int DeleteAll<T>()
			where T : DbTableBase, new()
		{
			lock (MosfinDatabase.locker)
			{
				return connection.DeleteAll<T>();
			}
		}

		public static int DeleteItem<T>(int id)
		where T : DbTableBase, new()
		{
			lock (MosfinDatabase.locker)
			{
				return MosfinDatabase.connection.Delete<T>(id);
			}
		}
    }
}
