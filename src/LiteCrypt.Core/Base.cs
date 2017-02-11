namespace LiteCrypt.Core
{
    public class Cryptography
    {
        private string t;
        public string Text
        {
            get { return t; }
            set { t = value; }
        }
        public string FilePath
        {
            get { return t; }
            set { t = value; }
        }
    }
    public abstract class Symmetric : Cryptography, ISymmetric
    {
        public string Key { get; set; }
        public string IV { get; set; }
        public abstract string Decrypt(string cipherText, string key, string iv);
        public abstract string Encrypt(string plainText);
    }
    public interface ISymmetric
    {
        string Key { get; set; }
        string IV { get; set; }
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