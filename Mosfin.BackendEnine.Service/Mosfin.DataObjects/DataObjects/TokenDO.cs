using System;
using Newtonsoft.Json;

namespace Mosfin.DataObjects.DataObjects
{
    public class TokenDO
    {
		[JsonProperty("unique_name")]
		public string UniqueName { get; set; }
		[JsonProperty("nameid")]
		public string nameid { get; set; }
		[JsonProperty("mosfin-customer-id")]
		public string AlatCustomerId { get; set; }
		[JsonProperty("mosfin-device-verified")]
		public bool AlatDeviceVerified { get; set; }
		[JsonProperty("nbf")]
		public string NBF { get; set; }
		[JsonProperty("exp")]
		public string EXP { get; set; }
		[JsonProperty("iat")]
		public string IAT { get; set; }
		[JsonProperty("iss")]
		public string ISS { get; set; }
		[JsonProperty("aud")]
		public string AUD { get; set; }
        public string Token { get; set; }
    }
}
