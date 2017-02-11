using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LiteCrypt.Core
{
    public class AES : Symmetric
    {
        public AES() { }
        public AES(string text)
        {
            this.Text = text;
        }
        public AES(string text, string key, string iv)
        {
            this.Text = text;
            this.Key = key;
            this.IV = iv;
        }
        public override string Encrypt(string plainText)
        {
            try
            {
                System.Security.Cryptography.Aes aes = System.Security.Cryptography.Aes.Create();
                byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
                this.Key = Convert.ToBase64String(aes.Key).Replace("-", "");
                this.IV = Convert.ToBase64String(aes.IV).Replace("-", "");
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputBytes, 0, inputBytes.Length);
                cs.FlushFinalBlock();
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
        public override string Decrypt(string cipherText, string key, string iv)
        {
            try
            {
                System.Security.Cryptography.Aes aes = System.Security.Cryptography.Aes.Create();
                byte[] inputBytes = Convert.FromBase64String(cipherText);
                aes.Key = Convert.FromBase64String(key);
                aes.IV = Convert.FromBase64String(iv);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputBytes, 0, inputBytes.Length);
                cs.FlushFinalBlock();
                return Encoding.UTF8.GetString(ms.ToArray());
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
