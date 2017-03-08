using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Nsdn.LiteCrypt
{
    public class TripleDES : Symmetric
    {
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
        public override string Encrypt(string plainText)
        {
            try
            {
                System.Security.Cryptography.TripleDES tdes = System.Security.Cryptography.TripleDES.Create();
                byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
                this.Key = Convert.ToBase64String(tdes.Key).Replace("-", "");
                this.IV = Convert.ToBase64String(tdes.IV).Replace("-", "");
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, tdes.CreateEncryptor(), CryptoStreamMode.Write);
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
                System.Security.Cryptography.TripleDES tdes = System.Security.Cryptography.TripleDES.Create();
                byte[] inputBytes = Convert.FromBase64String(cipherText);
                tdes.Key = Convert.FromBase64String(key);
                tdes.IV = Convert.FromBase64String(iv);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, tdes.CreateDecryptor(), CryptoStreamMode.Write);
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
