using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mosfin.BackendEnine.Service.Contracts;
using Mosfin.BackendEnine.Service.Utils;
using Mosfin.Clients.Common.Contracts.Utils;
using Mosfin.DataObjects.DataObjects;

namespace Mosfin.BackendEnine.Service.Implementation
{
    public class SetupItemClient:ISetupItemClient
    {
        
        public async Task<List<BankDO>> GetBanks()
        {

            using(MosfinRestClient client = new MosfinRestClient())
            {
                return await client.GetJSON<List<BankDO>>(Configs.REQUEST_ACCOUNT_STATEMENT_URL);
            }

        }

        public async Task<List<CityDO>> GetCities(int stateId,int countryid)
        {
			using (MosfinRestClient client = new MosfinRestClient())
			{
				return await client.GetJSON<List<CityDO>>(Configs.REQUEST_ACCOUNT_STATEMENT_URL);
			}
        }

        public async Task<List<LgaDO>> GetLgas(int stateId)
        {
			using (MosfinRestClient client = new MosfinRestClient())
			{
				return await client.GetJSON<List<LgaDO>>(Configs.REQUEST_ACCOUNT_STATEMENT_URL);
			}
        }

        public async Task<List<StateDO>> GetStates(int CountryId)
        {
			using (MosfinRestClient client = new MosfinRestClient())
			{
				return await client.GetJSON<List<StateDO>>(Configs.REQUEST_ACCOUNT_STATEMENT_URL);
			}
        }
    }
}
