using System;
using System.Text;

namespace LiteCrypt.Core
{
    /// <summary>
    /// Reference: http://www.2cto.com/kf/201204/127372.html
    /// </summary>
    public sealed class Base64 : Cryptography
    {
        public static string Encode(Encoding encode, string plainText)
        {
            byte[] bytes = encode.GetBytes(plainText);
            string cipherText;
            try
            {
                cipherText = Convert.ToBase64String(bytes);
            }
            catch
            {
                cipherText = plainText;
            }
            return cipherText;
        }
        public static string Encode(string plainText)
        {
            return Encode(Encoding.UTF8, plainText);
        }

        public static string Decode(Encoding encode, string cipherText)
        {
            string plainText = "";
            byte[] bytes = Convert.FromBase64String(cipherText);
            try
            {
                plainText = encode.GetString(bytes);
            }
            catch
            {
                plainText = cipherText;
            }
            return plainText;
        }
        public static string Decode(string cipherText)
        {
            return Decode(Encoding.UTF8, cipherText);
        }
    }
}