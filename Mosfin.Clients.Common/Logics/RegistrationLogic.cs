using System;
using System.Threading.Tasks;
using Flurl.Http;
using Mosfin.BackendEnine.Clients.Contracts;
using Mosfin.Clients.Utils.Utils;
using Mosfin.DataObjects;
using Mosfin.DataObjects.Models;

namespace Mosfin.Clients.Common.Logic
{
    public class RegistrationLogic:BaseLogic
    {
        readonly IRegistrationClient _registrationClient;
        [MosfinPreserveAttribute]
        public RegistrationLogic(IRegistrationClient registrationClient)
        {
            this._registrationClient = registrationClient;

        }

		public async Task Register(Action<PersonDO> onSuccess,
															Action<NetworkErrorModel> onError)
        {


			try
			{
                //var result = await _registrationClient.Register();

				if (onSuccess != null)
				{
                    onSuccess(null);
				}
			}
			catch (FlurlHttpException ex)
			{
				if (onError != null)
					HandleHttpError(onError, ex);
				
			}
			catch (Exception ex)
			{
				if (onError != null)
					onError(new NetworkErrorModel { Message = ex.Message });
			}

		}
    }
}
