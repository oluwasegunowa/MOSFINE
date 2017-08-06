using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Mosfin.BackendEnine.Service.Contracts;
using Mosfin.BackendEnine.Service.Implementation;
using Mosfin.Clients.Common.Contracts.Device;
using Mosfin.Clients.Common.Contracts.Utils;
using Mosfin.Clients.Common.Database;
using Mosfin.Clients.Common.Database.Tables;
using Mosfin.Clients.Common.Logic;
using Mosfin.Clients.Common.Services;
using Mosfin.Clients.Common.Utils;
using Mosfin.Clients.Utils.Utils;
using Mosfin.DataObjects.DataObjects;
using Mosfin.DataObjects.Models;
using Newtonsoft.Json;

namespace Mosfin.Clients.Common.Logics
{
    public class UserSessionLogic:BaseLogic
    {
        readonly IUserSessionClient _sessionClient;
		private IKeyValueStore _keyValueStore;
		private IFileSystemStorage _fileSystemStorage;

        public UserSessionLogic()
        {
        }



		
		
		[MosfinPreserveAttribute]
		public UserSessionLogic(IKeyValueStore keyValueStore, 
								  IFileSystemStorage fileSystemStorage)
		{
			this._keyValueStore = keyValueStore;
			this._fileSystemStorage = fileSystemStorage;
			
		}

		private DeviceUser _loggedInUser;

		public DeviceUser LoggedInUser
		{
			get
			{
				if (_loggedInUser == null)
				{
					string serializedUser = _keyValueStore.Get(Constants.Session.LOGGED_IN_USER);
                    _loggedInUser = JsonConvert.DeserializeObject<DeviceUser>(serializedUser);

				}
				return _loggedInUser;

			}
		}

		public String LoginName
        {
            get
            {
                return _keyValueStore.Get(Constants.Session.Login_Name);
            }
        }
		

		public void PersistUserLoginInfo(string email)
		{
			_keyValueStore.Set(Constants.Session.Login_Name, email);
		}

		public async void CreateUserLoginSession(LoginDO loginDO)
		{
			DeviceUser user = new DeviceUser();
			user.PhoneNo = loginDO.MobileNo;
			user.FullName = loginDO.FullName;
			user.DisplayPicture = loginDO.ProfilePicPath;
			var cachedImage = _fileSystemStorage.ReadFilePath(user.DisplayPicture ?? "avatar.png");
			user.LocalDisplayPicture = cachedImage ?? "images/avatar.png";
	
			SaveUserLoginData(user);
		}

		private void SaveUserLoginData(DeviceUser user)
		{
			string serializedUser = Newtonsoft.Json.JsonConvert.SerializeObject(user);
			_keyValueStore.Set(Constants.Session.LOGGED_IN_USER, serializedUser);
			_keyValueStore.Set(Constants.Session.IS_USER_LOGIN, true.ToString());
		}

		public void UpdateDisplayPictureCache(string localDisplayPicture)

		{
            DeviceUser user = this.LoggedInUser;
			user.LocalDisplayPicture = _fileSystemStorage.ReadFilePath(localDisplayPicture);
			string serializedUser = JsonConvert.SerializeObject(user);
			_keyValueStore.Set(Constants.Session.LOGGED_IN_USER, serializedUser);
			_keyValueStore.Set(Constants.Session.IS_USER_LOGIN, true.ToString());
		}

		public void ClearUserLoginSession()
		{
			_keyValueStore.Remove(Constants.Session.LOGGED_IN_USER);
			_keyValueStore.Set(Constants.Session.IS_USER_LOGIN, false.ToString());
		}

		public bool IsUserLoggedIn()
		{
			bool isLoggedin;
			var inTheKeyStore = _keyValueStore.Get(Constants.Session.IS_USER_LOGIN);
			var isLoggedInUser = Boolean.TryParse(inTheKeyStore, out isLoggedin) ? isLoggedin : false;
			return isLoggedInUser;
		}

		public void LogoutUser()
		{
			ClearUserLoginSession();
            //Create Plaform Functionality to Logout
			
		}


		

		public async Task ReIssueToken()
		{
			try
			{
				if (IsUserLoggedIn() && LoggedInUser.IsDeviceVerified)
				{
					var response = await _sessionClient.ReIssueToken();

					var user = LoggedInUser;
					user.Token = response.Token;

					_keyValueStore.Set(Constants.Session.LOGGED_IN_USER, JsonConvert.SerializeObject(user));
				}
			}
			catch (FlurlHttpException ex)
			{

			}
			catch (Exception ex)
			{

			}
		}

		public async Task ClearToken()
		{
			try
			{
				if (IsUserLoggedIn() && LoggedInUser.IsDeviceVerified)
				{
					var user = LoggedInUser;
					user.Token = "";

					_keyValueStore.Set(Constants.Session.LOGGED_IN_USER, JsonConvert.SerializeObject(user));
				}
			}
			catch (Exception ex)
			{

			}
		}
	
		
		

		

		

		
    }
}
