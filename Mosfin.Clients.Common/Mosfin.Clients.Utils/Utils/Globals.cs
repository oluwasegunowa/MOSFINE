using System;
using Mosfin.Clients.Common.Contracts.Utils;

namespace Mosfin.Clients.Common.Utils
{
	public static class Globals
	{
		private static DateTime LastActivityEpoch = DateTime.UtcNow;

		public static void UpdateActivityEpoch()
		{
			LastActivityEpoch = DateTime.UtcNow;
		}

		public static DateTime GetLastActivityEpoch()
		{
			return LastActivityEpoch;
		}

		public static bool IsSessionTimedOut()
		{
			return (DateTime.UtcNow - LastActivityEpoch).TotalSeconds > Constants.Session.TIMEOUT;
		}
	}
}
