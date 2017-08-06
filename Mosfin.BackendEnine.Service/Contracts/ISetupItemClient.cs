using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mosfin.DataObjects.DataObjects;

namespace Mosfin.BackendEnine.Service.Contracts
{
    public interface ISetupItemClient
    {
		 Task<List<BankDO>> GetBanks();
         Task<List<StateDO>> GetStates(int countryId);
         Task<List<CityDO>> GetCities(int stateId, int countryid);
         Task<List<LgaDO>> GetLgas(int stateId);
    }
}
