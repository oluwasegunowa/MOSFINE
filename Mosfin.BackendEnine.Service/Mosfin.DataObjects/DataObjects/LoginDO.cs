using System;
namespace Mosfin.DataObjects.DataObjects
{
    public class LoginDO
    {
       

        public string ProfilePicPath { get; set; }
        public string FullName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
      
    }


	public class BiometricLoginDO
	{
	
		public string Email { get; set; }
		public string Token { get; set; }
        public string LocalPolicy { get; set; }
        public string Password { get; set; }
    }
}
