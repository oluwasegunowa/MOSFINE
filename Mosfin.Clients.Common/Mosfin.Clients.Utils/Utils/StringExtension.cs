using System;
using System.Text.RegularExpressions;

namespace Mosfin.Clients.Common.Utils
{
	public static class StringExtension
	{
		public static byte[] ExtractDataFromBase64String(this string stringValue)
		{
			var splitedToken = stringValue.Split('.');

			if (splitedToken.Length != 3)
				throw new ArgumentException("Login error");

			var split = splitedToken[1]
				.PadRight(splitedToken[1].Length + (4 - splitedToken[1].Length % 4) % 4, '=');

			byte[] data = Convert.FromBase64String(split);
			return data;
		}

		public static string ExtractPhoneNumber(this string number)
		{

			number = number.RegexReplace(@"[-_()]", "")
						   .RegexReplace(@"\s*", "")
						   .RegexReplace(@"^[+]*234[0]*", "0");

			if (!number.StartsWith("0", StringComparison.OrdinalIgnoreCase)) number = "0" + number;
			if (!Regex.IsMatch(number, @"^\d{11}$")) return string.Empty;
			if (!Regex.IsMatch(number, @"^0[789]")) return string.Empty;
			return number;
		}
		public static string RegexReplace(this string number, string pattern, string replacement)
		{
			return Regex.Replace(number, pattern, replacement);
		}
		public static string GetAmountWithComma(this string amount)
		{
			var result = "";
			try
			{
				result = string.Format("{0:#,##0}",
					  Convert.ToDecimal(amount.GetAmountWithoutComma()));
			}
			catch (Exception ex)
			{

			}
			return result;
		}
		public static string GetAmountWithoutComma(this string amount)
		{
			var result = "";
			try
			{
				result = Convert.ToDecimal(amount.Replace(",", "")).ToString();
			}
			catch (Exception ex)
			{

			}
			return result;
		}
		public static string MaskCardPan(this string cardNumber)
		{
			string firstPart = cardNumber.Substring(0, 4);
			string secondPart = cardNumber.Substring(4, 2);
			string thirdPart = cardNumber.Substring(12);

			return $"{firstPart} {secondPart}** **** {thirdPart}";
		}
	}
}
