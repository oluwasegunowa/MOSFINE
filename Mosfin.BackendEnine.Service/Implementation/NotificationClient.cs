using System;
using System.Threading.Tasks;
using Mosfin.BackendEnine.Clients.Contracts;
using Mosfin.BackendEnine.Service;
using Mosfin.BackendEnine.Service.Utils;
using Mosfin.Clients.Common.Contracts.Utils;
using Mosfin.DataObjects;

namespace Mosfin.BackendEnine.Clients.Implementation
{
    public class NotificationClient:BaseClient, INotificationClient
    {
		MosfinRestClient client = new MosfinRestClient();

		public NotificationClient()
        {
            
        }


		public async Task<PersonDO> RequestStatement(PersonDO accountStatementDO)
		{
			return await client.PostJSON<PersonDO>(Configs.GET_TRANSACTION_LIMIT_URL, accountStatementDO);
		}
    }
}
