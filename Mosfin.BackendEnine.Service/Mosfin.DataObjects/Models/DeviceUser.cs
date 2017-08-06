using System;
using System.Text;
using Mosfin.DataObjects.DataObjects;

namespace Mosfin.DataObjects.Models
{
    public class DeviceUser
    {
        public DeviceUser()
        {
        }



		private string _fullName;
		public String FullName
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_fullName))
				{
					if (_tokenDo != null)
					{
						return _tokenDo.UniqueName;
					}
				}
				return _fullName;
			}
			set
			{
				_fullName = value;
			}
		}
		private string _displayPicture;
		public string DisplayPicture
		{
			get { return _displayPicture; }
			set
			{
				_displayPicture = value;
			}
		}

		public bool RequiresUpgrade { get; set; }
		public string LocalDisplayPicture { get; set; }
		public string PhoneNo { get; set; }
		public String CustomerId { get { return _tokenDo.AlatCustomerId; } }
	
		private string _token;
		private TokenDO _tokenDo;

		


		

		private byte[] ExtractDataFromBase64String()
		{
			var splitedToken = _token.Split('.');

			if (splitedToken.Length != 3)
				throw new ArgumentException();

			var split = splitedToken[1]
				.PadRight(splitedToken[1].Length + (4 - splitedToken[1].Length % 4) % 4, '=');

			byte[] data = Convert.FromBase64String(split);
			return data;
		}

		public bool IsDeviceVerified
		{
			get
			{

				return _tokenDo.AlatDeviceVerified;
			}
		}

		public bool IsDisplayPictureCached
		{
			get
			{
				return String.Equals(DisplayPicture, LocalDisplayPicture);
			}
		}

		public string MaskedPhoneNo
		{
			get
			{
				if (string.IsNullOrEmpty(PhoneNo))
					return "";
				var intlNumber = string.Equals(PhoneNo[0], '0')
									   ? "+234" + PhoneNo.Substring(1)
									   : "+" + PhoneNo;
				string firstPart = intlNumber.Substring(0, 4);
				string midPart = new string('*', intlNumber.Length - 8);
				string thirdPart = intlNumber.Substring(intlNumber.Length - 4);

				return $"{firstPart}{midPart}{thirdPart}";
			}
		}
		public string ReferralCode { get; set; }
        public string Token { get; set; }
    }
}
