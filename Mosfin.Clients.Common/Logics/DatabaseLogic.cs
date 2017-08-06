using System;
using System.Linq;
using Mosfin.Clients.Common.Database;
using Mosfin.Clients.Common.Database.Tables;
using Mosfin.Clients.Common.Services;
using Mosfin.DataObjects.DataObjects;

namespace Mosfin.Clients.Common.Logics
{
    public class DatabaseLogic
    {
        public DatabaseLogic()
        {
        }

       

        public void PerformDatabaseInitialization()
		{

            //CheckLocalKey With ServiceKey, if it's different; Load

			//DIFactory.Resolve<AirtimeService>().GetBillerCategories((obj) =>
		   //{
			  // AlatDatabase.DeleteAll<TempBillerCategoryDO>();
			  // AlatDatabase.InsertAll(obj);
		   //}, (obj) =>
		   //{

		   //});


		
            if (!MosfinDatabase.GetItems<StateTable>().Any() )
			{
				
			}
		}
    }
}
