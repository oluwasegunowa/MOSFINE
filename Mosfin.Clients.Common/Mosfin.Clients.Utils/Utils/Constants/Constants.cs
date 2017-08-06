using System;
namespace Mosfin.Clients.Common.Contracts.Utils
{
	public static class Constants
	{
		public static class App
		{
			public static string AppName = "Mosfin";
		}
		public static class TestFairy
		{
			public static string SdkKey = "2e994643bb27f4bdb5c8d350d112ee490fa443a0";
		}
        public static class Session
        {
            public static string Login_Name = "LOGINNAME";
            public static String IS_USER_LOGIN = "IsUserLoggedIn";
            public static String LOGGED_IN_USER = "LoggedInUser";
            internal static double TIMEOUT = 300;
        }

		public static class Analytics
		{
            
            #if QA
            public const string TrackingId = "UA-91342981-2";
            #elif STAGING
            public const string TrackingId = "UA-91342981-3";
            #elif PROD
            public const string TrackingId = "UA-91342981-4";
            #else
			public const string TrackingId = "UA-91342981-1";
            #endif

			public const int DispatchInterval = 30;

			public static string Saved;

            public static class Screens
            {

                public const string ConfirmDetails = "Confirm Details";
                public const string LandingPage ="Landing Page";
            }

			public static class Categories
			{
				public const string Onboarding = "Onboarding";

			}
			public static class EventLabels
			{
				//Payment Events
				public static string Payment_Airtime_Started = "Payment_Airtime_Started";
					

			}
			public static class Events
			{
				public const string Started = "Started";
				public const string Cancelled = "Cancelled";
				public const string Completed = "Completed";
                public const string View = "View";
				public const string Ssaved = "Saved";
				public const string Retried = "Retried";
				public const string Paused = "Paused";
				public const string Modified = "Modified";
				public const string Deleted = "Deleted";
				public const string Failed = "Failed";
				public const string Enabled = "Enabled";
                public const string Disbaled = "Disbaled";

			}
		}
	}
}
