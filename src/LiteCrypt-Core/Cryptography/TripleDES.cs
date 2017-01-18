using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace LiteCrypt
{
    public class TripleDES : Cryptography, ISymmetric
    {
        public string IV { get; set; }
        public string Key { get; set; }
        public TripleDES() { }
        public TripleDES(string text)
        {
            this.Text = text;
        }
        public TripleDES(string text, string key, string iv)
        {
            this.Text = text;
            this.Key = key;
            this.IV = iv;
        }
        public string Encrypt(string plainText)
        {
            try
            {
                System.Security.Cryptography.TripleDES tdes = System.Security.Cryptography.TripleDES.Create();
                byte[] inputBytes = Encoding.Unicode.GetBytes(plainText);
                this.Key = Convert.ToBase64String(tdes.Key).Replace("-", "");
                this.IV = Convert.ToBase64String(tdes.IV).Replace("-", "");
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, tdes.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputBytes, 0, inputBytes.Length);
                cs.FlushFinalBlock();
                //StringBuilder sb = new StringBuilder();
                //foreach (byte b in ms.ToArray())
                //{
                //    sb.AppendFormat("{0:X2}", b);
                //}
                //string s = sb.ToString();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception e)
            {
                return "\nERROR: " + e.Message;
            }
        }
        public string Encrypt()
        {
            return this.Encrypt(this.Text);
        }
        public string Decrypt(string cipherText, string key, string iv)
        {
            try
            {
                System.Security.Cryptography.TripleDES tdes = System.Security.Cryptography.TripleDES.Create();
                byte[] inputBytes = Convert.FromBase64String(cipherText);
                //string cipherTextString = cipherTextBytesBase64.ToString();
                //byte[] inputBytes = new byte[cipherText.Length / 2];
                //for (int x = 0; x < cipherText.Length / 2; x++)
                //{
                //    int i = (Convert.ToInt32(cipherTextString.Substring(x * 2, 2), 16));
                //    inputBytes[x] = (byte)i;
                //}
                tdes.Key = Convert.FromBase64String(key);
                tdes.IV = Convert.FromBase64String(iv);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, tdes.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputBytes, 0, inputBytes.Length);
                cs.FlushFinalBlock();
                return System.Text.Encoding.Unicode.GetString(ms.ToArray());
            }
            catch (Exception e)
            {
                return "\nERROR: " + e.Message;
            }
        }
        public string Decrypt()
        {
            return this.Decrypt(this.Text, this.Key, this.IV);
        }
    }
}
