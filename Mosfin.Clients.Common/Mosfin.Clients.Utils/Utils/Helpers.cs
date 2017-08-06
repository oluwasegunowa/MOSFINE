using System;
using System.Text;
using System.Text.RegularExpressions;
using PCLCrypto;

namespace Mosfin.Clients.Common.Utils
{
	public class Helpers
	{
		public static double CurrentTimestamp()
		{
			return (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
		}

		public static bool ValidateEmail(string inputEmail)
		{
			string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
				  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
				  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
			Regex regEx = new Regex(strRegex);
			if (regEx.IsMatch(inputEmail))
				return (true);
			else
				return (false);
		}
        #if QA
        static string[] PINNED_KEYS = {
                                    "3082010A0282010100AFD4FB873CE4C969CF4FAC2C0D7E5E372306F7E438CD7B1061B14E1E154983433CD329DAEFC64AAE295C22A942CECF061D1D2D27EAF61852982DE646BDC14B7A91011C0751D755F468CFCBDDB531C765DEB3E72FBF24035248E5552C5FE4D4E47301B04044E2DC5527511784A6CF4C9F513384CAB75EC3D8978C058BD86B097D8A594AF143DE4F20988EA565502C326CB470419ECFE9BF34A2AEFBCE6FE6646A3A454CEC12FD39097F746512AA524CA13B1A080B23B695A4FEDD5E382B15ABDF705ECCAC25F3F2636B36A00CAA6816325B6EDFFE94D1DDF8C9E57BD5F5EA7B003858B7A2321F4650681C873FD017443F18BA0CCF68F2D005BF795DF1FE8DD4AD0203010001"
                                 };
        #elif STAGING
        static string[] PINNED_KEYS = {
                                    "3082010A0282010100AA88BB403938F0D1EE2A8A55F8DEA7DF29DFA6F8DD737425A2FAC3B3C102630A53598CC9B897D1AC308CB0CC7140C7308470552753BE18605963BE97C030881F61BB158B9A6CFE7F40D9624629A8712E92F380E8AB3B4FFBD6DE4C6B284A39B7EB8F85BC2B669C4AF11958C46B4C0514B003C46975BFE89BAE8213EEDE18F11AAC1FA2D155AB8F9ACDE43EC21432BF7B444787A87951AC2FFCFB4F5FEE3904E2A5470F63BDBC3586C6D25F530C2802BA178BAE7EC9418C54A0833426AB069FD626DC007D6C60F71E5F9FB7D643CD436C3F0B3A3E7D50610374B806348F588462575844EF5E7F88924DA67A049770F6610005AA3D75A8A8369128BADBD5CDC5DB0203010001"
                                 };
        #elif PROD
        static string[] PINNED_KEYS = {
                                    "3082010A0282010100B15E83766B95DF5D29FB105C67A130C855A0AE58F8838C14B6EB234BE3F62FEAC4F74DA98EA38CE1F4B5B39A3DA625541E9689458865CD12944B029F2468FCA52BD18D8C2CCEF53CB599704B92866BB43FEB57153F5CB3415671C87ED5D0FAFF8D9763A5CDAFEFBF33A2485F8A6D7648A706B4477BF0DD5D45B8861BBBF24563F61AA5953ED42286F5A490098B581CBFC87B0807EB4E5154741C24F2D3041D1BBBEC4E681D36144DB3B907567484947C34072800C781BEABD5E8B3C66DB8BC24EE72D13D7A81F35A1D77DFAF63296A5600FBAF53C9E903D9090E9D00D2376D64FCAFA35C273F9E82BF241FB8E512F825599A60EDCE4C9DEA600C2EEA3A8AAB3F0203010001"
                                 };

        #else
		static string[] PINNED_KEYS = {
									"3082010A02820101008D41BED29F89F39255CD52D3C9DA3C333C18D9BEB1383F9A2862BA8E52CB3138CAC160FB47C67E85C638E0A7CA8D1C47374B0869C904C64AEF96A195793B3C45E2558FFB33E2195561AAABC8B370633F74D64C4F1DFD009E8B1D5A3FE64E4476B8501A5288F788DCF6DDFD1FF61730D7F7051D4C7FA47CF67FD53DC824DB4E82636EB7F8AEFC9923F43DC15BE34C4BE9928F1AABC8093BE2F138578B2E488ADF2C9A9C868CF0A9CCFB4951387F2943563CD7A2A3E6022A5EF9372F3CF0B9F1E46AC0FF2DC46ECB889605B85954FFF822CF021EDE47D15A7D51590529C0205A35B985DF766CE1162C0DB6580CFD05558AC7DE1AF8AC2D1F0FBECEB3A1CC70EB6B0203010001",
									"3082010A0282010100CE551A8679F591CB308CF3CC5F3FC92B67432EB8E7B29363802D7E17257B92C4FFB30C49BBBB9FBA39B9555E8D0E589320B9EB75F4F7768A5EC4716CE130DD5074CC8551E1123637948A9C36167E82D056EF1D725EB42F72D9F5087DF7FFD338FDD8084CFDDD47161197B131065C07DEAACF209456D89743AEC59E6DA552B338DE8A9DCC0EE3EA7D83C011758B050A67F8B2C3285751E639CC2319FA7AEC2C3246A230016725253EDBB0DDA45DF0134809C04954273AFBC62295CE47BC81D6618A0987AA7E3667E7BE15CFABD5F056A6037C09005BD2EF8E26894C0AF25EE697B7A6CD402D8641D89754B1548BCD97DFBB57DE343D664CC4BF7A4BCB80285BEF0203010001"
								 };
        #endif
		public static bool IsCertificateKeyRecognised(string certificateKey)
		{
			foreach (string key in PINNED_KEYS)
			{
				if (certificateKey == key)
					return true;
			}
			return false;

		}


		public static long ConvertToJavaLangDateTime(DateTime dateTime)
		{
			long epochTicks = new DateTime(1970, 1, 1).Ticks;
			return ((dateTime.Ticks - epochTicks) / TimeSpan.TicksPerMillisecond);
		}


		public static bool IsPasswordValid(string passwordString)
		{
			var regex = "^(?=.*[a-z])(?=.*\\d)(?=.*(_|[^\\w])).{8,50}$";
			return Regex.Match(passwordString, regex, System.Text.RegularExpressions.RegexOptions.IgnoreCase).Success;
		}

		public static bool IsPhoneNumberValid(string passwordString)
		{
			var regex = "^1?(\\d{10})";
			return Regex.Match(passwordString, regex, System.Text.RegularExpressions.RegexOptions.IgnoreCase).Success;
		}

		public static bool IsOTPValid(string otpString)
		{
			var regex = "^\\d{1,6}$";
			return Regex.Match(otpString, regex, System.Text.RegularExpressions.RegexOptions.IgnoreCase).Success;
		}

		public static String FormatAmountToCurrency(String currency)
		{
			String symbols = "NGN";
			if ("NGN".Equals(currency))
				symbols = "₦";
			if ("USD".Equals(currency))
				symbols = "$";
			if ("GBP".Equals(currency))
				symbols = "£";
			if ("EUR".Equals(currency))
				symbols = "€";
			if ("JPY".Equals(currency))
			{
				symbols = "¥";
			}
			return symbols;

		}

		public static String FormatAmountToCurrency(String currency, Double amount)
		{
			String symbols = "NGN";
			if ("NGN".Equals(currency))
				symbols = "₦";
			if ("USD".Equals(currency))
				symbols = "$";
			if ("GBP".Equals(currency))
				symbols = "£";
			if ("EUR".Equals(currency))
				symbols = "€";
			if ("JPY".Equals(currency))
			{
				symbols = "¥";
			}
			String credits = symbols + " " + String.Format("{0:N2}", amount);
			return credits;

		}


		private static string Encrypt(string data)
		{
			var asym = PCLCrypto.WinRTCrypto.AsymmetricKeyAlgorithmProvider.OpenAlgorithm(AsymmetricAlgorithm.RsaPkcs1);
			var publicKeyData = Convert.FromBase64String("MEgCQQCwN4dAP74skx2AMtTrhHMHAL3cr3zF/6Ahr4sGVK29u9her7z9OB/6g3FyEGRI2D6AdIBGVXycK4iNTAuNXm/lAgMBAAE=");
			var publicKey = asym.ImportPublicKey(publicKeyData, CryptographicPublicKeyBlobType.Pkcs1RsaPublicKey);
			var dataBytes = Encoding.UTF8.GetBytes(data);
			var encrypted = PCLCrypto.WinRTCrypto.CryptographicEngine.Encrypt(publicKey, dataBytes);
			var encryptedString = Convert.ToBase64String(encrypted);
			return encryptedString;
		}


		private static string DeEncrypt(string data)
		{
			var asym = PCLCrypto.WinRTCrypto.AsymmetricKeyAlgorithmProvider.OpenAlgorithm(AsymmetricAlgorithm.RsaPkcs1);
           
			var publicKeyData = Convert.FromBase64String("MEgCQQCwN4dAP74skx2AMtTrhHMHAL3cr3zF/6Ahr4sGVK29u9her7z9OB/6g3FyEGRI2D6AdIBGVXycK4iNTAuNXm/lAgMBAAE=");
			var publicKey = asym.ImportPublicKey(publicKeyData, CryptographicPublicKeyBlobType.Pkcs1RsaPublicKey);
			var dataBytes = Encoding.UTF8.GetBytes(data);
            var decrypted = PCLCrypto.WinRTCrypto.CryptographicEngine.Decrypt(publicKey, dataBytes);
			var decryptedString = Convert.ToBase64String(decrypted);
			return decryptedString;
		}

	}
}
