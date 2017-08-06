using System;
namespace Mosfin.DataObjects.DataObjects
{
    public class ApplicationInfoDO
    {
		public string DeviceCode { get; set; }
		public object ChannelId { get; set; }
		public string DeviceName { get; set; }
		public string DeviceOS { get; set; }
		public string GCMId { get; set; }
		public string ApplicationVersion { get; set; }
		public string LocalPolicy { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Altitude { get; set; }
        public bool IsDeviceBiometricEnabled { get; set; }
    }
}
