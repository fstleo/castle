using UnityEngine;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Assets.Crypto
{
    public class MemoryCrypto
    {
        public static byte[] Key
        {
            get
            {
                if (PlayerPrefs.HasKey("aaaa"))
                    return Encoding.UTF8.GetBytes(PlayerPrefs.GetString("aaaa"));
                else
                {
                    Guid s = Guid.NewGuid();
                    PlayerPrefs.SetString("aaaa", s.ToString());
                    return s.ToByteArray();
                }
                    
            }
        }


#if UNITY_EDITOR
        public static string Encode(string value)
        {
            return value;
        }

        public static string Decode(string value)
        {
            return value;
        }
#else
            public static string Encode(string value)
            {
                return Convert.ToBase64String(Encode(Encoding.UTF8.GetBytes(value), Key));
            }

            public static string Decode(string value)
            {
                return Encoding.UTF8.GetString(Encode(Convert.FromBase64String(value), Key));
            }

            public static string Encrypt(string value, string key)
            {
                return Convert.ToBase64String(Encode(Encoding.UTF8.GetBytes(value), Encoding.UTF8.GetBytes(key)));
            }

            public static string Decrypt(string value, string key)
            {
                return Encoding.UTF8.GetString(Encode(Convert.FromBase64String(value), Encoding.UTF8.GetBytes(key)));
            }

            private static byte[] Encode(byte[] bytes, byte[] key)
            {
                var j = 0;

                for (var i = 0; i < bytes.Length; i++)
                {
                    bytes[i] ^= key[j];

                    if (++j == key.Length)
                    {
                        j = 0;
                    }
                }

                return bytes;
            }     
#endif
    }

    //public static class AESCrypto
    //{
    //    public static int keyLength = 128;
    //    private const string SaltK  = "AS13o4sdkfAJasldj@2~";
    //    private const string IVKey  = "a~j14@aslk5&453f";

    //    public static string Encrypt(byte [] value, string password)
    //    {
    //        var keyBytes = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(SaltK)).GetBytes(keyLength / 8);
    //        var symmetricKey = new RijndaelManaged { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
    //        var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.UTF8.GetBytes(IVKey));
    //        using (var memoryStream = new MemoryStream())
    //        {
    //            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
    //            {
    //                cryptoStream.Write(value, 0, value.Length);
    //                cryptoStream.FlushFinalBlock();
    //                cryptoStream.Close();
    //                memoryStream.Close();
    //                return Convert.ToBase64String(memoryStream.ToArray());
    //            }
    //        }
    //    }

    //    public static string Encrypt(string value, string password)
    //    {
    //        return Encrypt(Encoding.UTF8.GetBytes(value), password);
    //    }

    //    public static string Decrypt(string value, string password)
    //    {
    //        var cipherTextBytes = Convert.FromBase64String(value);
    //        var keyBytes = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(SaltK)).GetBytes(keyLength / 8);
    //        var symmetricKey = new RijndaelManaged { Mode = CipherMode.CBC, Padding = PaddingMode.None };
    //        var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.UTF8.GetBytes(IVKey));
    //        using (var memoryStream = new MemoryStream(cipherTextBytes))
    //        {
    //            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
    //            {
    //                var plainTextBytes = new byte[cipherTextBytes.Length];
    //                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
    //                memoryStream.Close();
    //                cryptoStream.Close();

    //                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
    //            }
    //        }
    //    }
    //}

}