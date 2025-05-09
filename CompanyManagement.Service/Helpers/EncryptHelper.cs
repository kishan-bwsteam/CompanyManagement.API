//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Service.Helpers
//{
//	class EncryptHelper
//	{
//	}
//}

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Authentication.DataManager.Helper
{

	public class EncryptHelperObj
	{
		public string SaltKey { get; set; }

		public string SaltKeyIV { get; set; }

		public string Value { get; set; }

		public byte[] EncryptString { get; set; }

		//public string EncryptString { get; set; }

	}
	public class EncryptHelper
	{

		static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
		{
			// Check arguments.
			if (plainText == null || plainText.Length <= 0)
				throw new ArgumentNullException("plainText");
			if (Key == null || Key.Length <= 0)
				throw new ArgumentNullException("Key");
			if (IV == null || IV.Length <= 0)
				throw new ArgumentNullException("IV");
			byte[] encrypted;

			// Create an Aes object
			// with the specified key and IV.
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Key = Key;
				aesAlg.IV = IV;

				// Create an encryptor to perform the stream transform.
				ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

				// Create the streams used for encryption.
				using (MemoryStream msEncrypt = new MemoryStream())
				{
					using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
						{
							//Write all data to the stream.
							swEncrypt.Write(plainText);
						}
						encrypted = msEncrypt.ToArray();
					}
				}
			}

			// Return the encrypted bytes from the memory stream.
			return encrypted;
		}

		static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
		{
			// Check arguments.
			if (cipherText == null || cipherText.Length <= 0)
				throw new ArgumentNullException("cipherText");
			if (Key == null || Key.Length <= 0)
				throw new ArgumentNullException("Key");
			if (IV == null || IV.Length <= 0)
				throw new ArgumentNullException("IV");

			// Declare the string used to hold
			// the decrypted text.
			string plaintext = null;

			// Create an Aes object
			// with the specified key and IV.
			using (Aes aesAlg = Aes.Create())
			{
				aesAlg.Key = Key;
				aesAlg.IV = IV;

				// Create a decryptor to perform the stream transform.
				ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

				// Create the streams used for decryption.
				using (MemoryStream msDecrypt = new MemoryStream(cipherText))
				{
					using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
					{
						using (StreamReader srDecrypt = new StreamReader(csDecrypt))
						{

							// Read the decrypted bytes from the decrypting stream
							// and place them in a string.
							plaintext = srDecrypt.ReadToEnd();
						}
					}
				}
			}
			return plaintext;
		}
        internal static object Get_DecryptedPassword(EncryptHelperObj obj, object passKey)
        {
            throw new NotImplementedException();
        }

        //Common Functions can be used in other projects Start
        private static bool CheckStringISNormal(string inputstring)
		{
			bool valueIsUnknown = false;
			Regex regex = new Regex(@"[A-Za-z0-9 àâäèéêëîïôœùûüÿçÀÂÄÈÉÊËÎÏÔŒÙÛÜŸÇáéíóúüñçÁÉÍÓÚÜÑÇ .,--_^!%$~#<>?"":;'`@&$*/=+(){}\[\]\\]");
			MatchCollection matches = regex.Matches(inputstring);

			if (matches.Count.Equals(inputstring.Length))
			{ valueIsUnknown = true; }
			else
			{ valueIsUnknown = false; }

			return valueIsUnknown;
		}

		public static string Get_DecryptedPassword(EncryptHelperObj _EncryptHelperObj, string EncryptString)
		{
			string Password = string.Empty;
			try
			{
				
					if (EncryptString.Length > 0)
				{
					byte[] st = Convert.FromBase64String(EncryptString);
					byte[] kst = Convert.FromBase64String(_EncryptHelperObj.SaltKey);
					Password = DecryptStringFromBytes_Aes(Convert.FromBase64String(EncryptString), Convert.FromBase64String(_EncryptHelperObj.SaltKey), Convert.FromBase64String(_EncryptHelperObj.SaltKeyIV));
				}
			}
			catch (Exception ex)
			{ Password = string.Empty; }

			return Password;
		}

		public static EncryptHelperObj Get_EncryptedPassword(EncryptHelperObj obj, string Password)
		{
			EncryptHelperObj _EncryptHelperObj = new EncryptHelperObj();
			if (CheckStringISNormal(Password))
			{
				try
				{
					if (Password.Length > 0)
					{
						using (Aes myAes = Aes.Create())
						{
							_EncryptHelperObj.EncryptString = EncryptStringToBytes_Aes(Password, myAes.Key, myAes.IV);
							_EncryptHelperObj.SaltKey = Convert.ToBase64String(myAes.Key);// Encoding.UTF8.GetString(myAes.Key);
							_EncryptHelperObj.SaltKeyIV = Convert.ToBase64String(myAes.IV);
							byte[] aa = Convert.FromBase64String(_EncryptHelperObj.SaltKey);

						}
					}
					else
					{ _EncryptHelperObj.EncryptString = null; }

				}
				catch
				{
					_EncryptHelperObj.EncryptString = null;
				}
				if (_EncryptHelperObj.EncryptString != null)
				{
					_EncryptHelperObj.Value = Convert.ToBase64String(_EncryptHelperObj.EncryptString);
				}
			}
			else
			{ _EncryptHelperObj.Value = Password; }

			return _EncryptHelperObj;
		}
		//Common Functions can be used in other projects End
	}
}

