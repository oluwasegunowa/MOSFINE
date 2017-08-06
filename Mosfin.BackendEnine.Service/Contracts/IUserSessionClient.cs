using System;
using System.Threading.Tasks;
using Mosfin.DataObjects.DataObjects;

namespace Mosfin.BackendEnine.Service.Contracts
{
    public interface IUserSessionClient
    {
        Task<TokenDO> ReIssueToken();
    }
}
