using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace LiteCrypt
{
    class SHA1 : Hash
    {
        public override string ComputeHashFromFile(string filePath)
        {
            throw new NotImplementedException();
        }

        public override string ComputeHashFromText(string text)
        {
            try
            {
                System.Security.Cryptography.SHA1 sha1 = System.Security.Cryptography.SHA1.Create();
                byte[] inputBytes = Encoding.Unicode.GetBytes(text);
                byte[] outputBytes = sha1.ComputeHash(inputBytes);
                return BitConverter.ToString(outputBytes).Replace("-", "");
            }
            catch (Exception e)
            {
                return "\nERROR: " + e.Message;
            }
        }
    }
}
