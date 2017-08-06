using System;
using System.Threading.Tasks;
using Mosfin.BackendEnine.Clients.Contracts;
using Mosfin.BackendEnine.Service;

namespace Mosfin.BackendEnine.Clients.Implementation
{
    public class RegistrationClient:BaseClient, IRegistrationClient
    {
        public RegistrationClient()
        {
            
        }

        public Task Register()
        {
            throw new NotImplementedException();
        }
    }
}
