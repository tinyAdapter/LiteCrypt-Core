using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace LiteCrypt
{
    class MD5 : Hash
    {
        public override string ComputeHashFromFile(string filePath)
        {
            throw new NotImplementedException();
        }

        public override string ComputeHashFromText(string text)
        {
            try
            {
                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = Encoding.Unicode.GetBytes(text);
                byte[] outputBytes = md5.ComputeHash(inputBytes);
                return BitConverter.ToString(outputBytes).Replace("-", "");
            }
            catch (Exception e)
            {
                return "\nERROR: " + e.Message;
            }
        }
    }
}
