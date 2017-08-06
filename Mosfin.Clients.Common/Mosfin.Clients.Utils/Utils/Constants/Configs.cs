using System;
namespace Mosfin.Clients.Common.Contracts.Utils
{
	/// <summary>
	/// This is a constant class that stores standard values
	/// </summary>
	public class Configs
	{
		//public const string Host = "196.43.215.157";
		public const string TEST_BACKEND_URL = "http://192.168.52.84/";

		//Environemnt specific constants
        #if QA
        public const string SERVICE_URL = "https://196.43.215.170/";
        public const string Environment = "QA Build";
        public const string SMS_SENDER = "Mosfin";
        #elif STAGING
        public const string SERVICE_URL = "https://196.43.215.172/";
        public const string Environment = "Pre-prod Build";
        public const string SMS_SENDER = "Mosfin";
        #elif PROD
        public const string SERVICE_URL = "https://api.alat.ng/";
        public const string Environment = "";
        public const string SMS_SENDER = "Mosfin";
        #else
		public const string SERVICE_URL = "https://196.43.215.156/";
		public const string SMS_SENDER = "Mosfin";
		public const string Environment = "Dev Build";
        #endif

		#region Google_Analytics        
		public const string TRACKER_ALLOW_TRACKING_KEY = "AllowTracking";
		#endregion

		#region Statics_For_KeyValueStore
		public static String SHOULD_POP_FUND_MY_ACCOUNT = "ShouldPopFundMyAccount";
		#endregion

		#region Terms&Condition

		public const string TERMS_AND_CONDITION_ACCOUNT_OPENING_URL = SERVICE_URL + "RegistrationApi/index.html";
		public const string TRANSACTION_LIMIT_INDEMNITY_RL = SERVICE_URL + "RegistrationApi/indemnity.html";

        public const int REST_REQUEST_TIMEOUT = 300;
		#endregion

        public const string REQUEST_ACCOUNT_STATEMENT_URL = SERVICE_URL + "AccountMaintenance/api/Transactions/statements";
		public const string GET_TRANSACTION_LIMIT_URL = SERVICE_URL + "AccountMaintenance/api/Transactions/gettransactionlimit";
        public const  string SEND_NOTIFICATION_TOKEN_URL = SERVICE_URL +"";
        public const  string REISSUE_TOKEN_URL = SERVICE_URL +"";
        public const  string LOGIN_URL = SERVICE_URL +"";
        public const  string LOGIN_WITH_BIOMETRICS_URL = SERVICE_URL +"";

        public static object CHANNEL_ID { get; set; }
    }
}
