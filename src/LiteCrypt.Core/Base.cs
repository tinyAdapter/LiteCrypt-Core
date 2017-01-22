using System;
using System.Collections.Generic;
using System.Text;

namespace LiteCrypt.Core
{
    public class Cryptography
    {
        public string Text { get; set; }
        public string FilePath { get; set; }
    }
    public interface ISymmetric
    {
        string Key { get; set; }
        string Encrypt(string plainText);
        string Decrypt(string cipherText, string key, string iv);
    }
    public interface IHash
    {
        string ComputeHashFromText(string text);
        string ComputeHashFromFile(string filePath);
    }
    public abstract class Hash : Cryptography, IHash
    {
        public abstract string ComputeHashFromFile(string filePath);
        public abstract string ComputeHashFromText(string text);
        public string ComputeHashFromText() { return this.ComputeHashFromText(this.Text); }
        public string ComputeHashFromFile() { return this.ComputeHashFromFile(this.FilePath); }
    }
}