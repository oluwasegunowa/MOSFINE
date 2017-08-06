using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mosfin.BackendEnine.Clients.Contracts;
using Mosfin.BackendEnine.Service;
using Mosfin.BackendEnine.Service.Utils;
using Mosfin.Clients.Common.Contracts.Utils;
using Mosfin.DataObjects;

namespace Mosfin.BackendEnine.Clients.Implementation
{
    public class AccountClient:BaseClient,IAccountClient
    {
        MosfinRestClient client = new MosfinRestClient();
		public async Task<List<PersonDO>> GetPersonAsync()
		{
            
            return await client.GetJSON<List<PersonDO>>(Configs.REQUEST_ACCOUNT_STATEMENT_URL);
		}

    }
}
