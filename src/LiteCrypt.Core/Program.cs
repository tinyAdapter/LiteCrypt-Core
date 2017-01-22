using System;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using LiteCrypt.Core;

namespace LiteCrypt
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            //!->Has Arguments
            if (args.Length != 0)
            {
                foreach (string arg in args)
                {
                    FullHashCalc(arg);
                }
            }
            else
            {
                char ch;
                //Print Title
                PrintTitle();
                //Print Cryptography Table
                PrintCryptographyTable();
                while (true)
                {
                    ch = Console.ReadKey().KeyChar;
                    if (ch == '1')//Triple-DES
                    {
                        Core.TripleDES tdes = new Core.TripleDES();
                        Console.Write("\nChoose Encrypt or Decrypt [e/d]: ");

                        while (true)
                        {
                            ch = Console.ReadKey().KeyChar;
                            if (ch == 'e' || ch == 'E')
                            {
                                Console.Write("\nInput PlainText: ");
                                tdes.Text = Console.ReadLine();

                                string cipherText = tdes.Encrypt();
                                Console.WriteLine($"Get Random Key: {tdes.Key}");
                                Console.WriteLine($"Get Random IV: {tdes.IV}");
                                Console.WriteLine($"The Cipher Text is: {cipherText}");
                                break;
                            }
                            else if (ch == 'd' || ch == 'D')
                            {
                                Console.Write("\nInput CipherText: ");
                                tdes.Text = Console.ReadLine();

                                Console.Write("Input Key: ");
                                tdes.Key = Console.ReadLine();
                                Console.Write("Input IV: ");
                                tdes.IV = Console.ReadLine();

                                string plainText = tdes.Decrypt();
                                Console.WriteLine($"The Plain Text is: {plainText}");
                                break;
                            }
                        }
                        break;
                    }
                    else if (ch == '2')//MD5
                    {
                        Core.MD5 md5 = new Core.MD5();
                        Console.Write("\nChoose File or Text [f/t]: ");

                        while (true)
                        {
                            ch = Console.ReadKey().KeyChar;
                            if (ch == 'f' || ch == 'F')
                            {
                                Console.Write("\nInput File Path: ");
                                md5.FilePath = Console.ReadLine();
                                string hashCode = md5.ComputeHashFromFile();
                                Console.WriteLine($"The MD5 Code is: {hashCode}");
                                break;
                            }
                            else if (ch == 't' || ch == 'T')
                            {
                                Console.Write("\nInput Text: ");
                                md5.Text = Console.ReadLine();
                                string hashCode = md5.ComputeHashFromText();
                                Console.WriteLine($"The MD5 Code is: {hashCode}");
                                break;
                            }
                        }
                        break;
                    }
                    else if (ch == '3')//SHA1
                    {
                        Core.SHA1 sha1 = new Core.SHA1();
                        Console.Write("\nChoose File or Text [f/t]: ");

                        while (true)
                        {
                            ch = Console.ReadKey().KeyChar;
                            if (ch == 'f' || ch == 'F')
                            {
                                Console.Write("\nInput File Path: ");
                                sha1.FilePath = Console.ReadLine();
                                string hashCode = sha1.ComputeHashFromFile();
                                Console.WriteLine($"The SHA1 Code is: {hashCode}");
                                break;
                            }
                            else if (ch == 't' || ch == 'T')
                            {
                                Console.Write("\nInput Text: ");
                                sha1.Text = Console.ReadLine();
                                string hashCode = sha1.ComputeHashFromText();
                                Console.WriteLine($"The SHA1 Code is: {hashCode}");
                                break;
                            }
                        }
                        break;
                    }
                    else if (ch == '4')//SHA256
                    {
                        Core.SHA256 sha256 = new Core.SHA256();
                        Console.Write("\nChoose File or Text [f/t]: ");

                        while (true)
                        {
                            ch = Console.ReadKey().KeyChar;
                            if (ch == 'f' || ch == 'F')
                            {
                                Console.Write("\nInput File Path: ");
                                sha256.FilePath = Console.ReadLine();
                                string hashCode = sha256.ComputeHashFromFile();
                                Console.WriteLine($"The SHA256 Code is: {hashCode}");
                                break;
                            }
                            else if (ch == 't' || ch == 'T')
                            {
                                Console.Write("\nInput Text: ");
                                sha256.Text = Console.ReadLine();
                                string hashCode = sha256.ComputeHashFromText();
                                Console.WriteLine($"The SHA256 Code is: {hashCode}");
                                break;
                            }
                        }
                        break;
                    }

                    else if (ch == '5')//SHA384
                    {
                        Core.SHA384 sha384 = new Core.SHA384();
                        Console.Write("\nChoose File or Text [f/t]: ");

                        while (true)
                        {
                            ch = Console.ReadKey().KeyChar;
                            if (ch == 'f' || ch == 'F')
                            {
                                Console.Write("\nInput File Path: ");
                                sha384.FilePath = Console.ReadLine();
                                string hashCode = sha384.ComputeHashFromFile();
                                Console.WriteLine($"The SHA384 Code is: {hashCode}");
                                break;
                            }
                            else if (ch == 't' || ch == 'T')
                            {
                                Console.Write("\nInput Text: ");
                                sha384.Text = Console.ReadLine();
                                string hashCode = sha384.ComputeHashFromText();
                                Console.WriteLine($"The SHA384 Code is: {hashCode}");
                                break;
                            }
                        }
                        break;
                    }

                    else if (ch == '6')//SHA512
                    {
                        Core.SHA512 sha512 = new Core.SHA512();
                        Console.Write("\nChoose File or Text [f/t]: ");

                        while (true)
                        {
                            ch = Console.ReadKey().KeyChar;
                            if (ch == 'f' || ch == 'F')
                            {
                                Console.Write("\nInput File Path: ");
                                sha512.FilePath = Console.ReadLine();
                                string hashCode = sha512.ComputeHashFromFile();
                                Console.WriteLine($"The SHA512 Code is: {hashCode}");
                                break;
                            }
                            else if (ch == 't' || ch == 'T')
                            {
                                Console.Write("\nInput Text: ");
                                sha512.Text = Console.ReadLine();
                                string hashCode = sha512.ComputeHashFromText();
                                Console.WriteLine($"The SHA512 Code is: {hashCode}");
                                break;
                            }
                        }
                        break;
                    }
                    else if (ch == '7')//CRC32
                    {
                        Core.CRC32 crc32 = new Core.CRC32();
                        Console.Write("\nChoose File or Text [f/t]: ");

                        while (true)
                        {
                            ch = Console.ReadKey().KeyChar;
                            if (ch == 'f' || ch == 'F')
                            {
                                Console.Write("\nInput File Path: ");
                                crc32.FilePath = Console.ReadLine();
                                string hashCode = crc32.ComputeHashFromFile();
                                Console.WriteLine($"The CRC32 Code is: {hashCode}");
                                break;
                            }
                            else if (ch == 't' || ch == 'T')
                            {
                                Console.Write("\nInput Text: ");
                                crc32.Text = Console.ReadLine();
                                string hashCode = crc32.ComputeHashFromText();
                                Console.WriteLine($"The CRC32 Code is: {hashCode}");
                                break;
                            }
                        }
                        break;
                    }
                    else if (ch == 'f' | ch == 'F')//FULL HASH
                    {
                        FullHashCalc(String.Empty);
                        break;
                    }
                }
            }
            Console.ReadKey();
        }

        public static void PrintTitle()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("=\t\t\t\t\t=");
            Console.WriteLine("=\tLiteCrypt.Core\t\t\t=");
            Console.WriteLine("=\tCreated By tinyAdapter\t\t=");
            Console.WriteLine("=\t\t\t\t\t=");
            Console.WriteLine("=========================================");
        }

        public static void PrintCryptographyTable()
        {
            Console.WriteLine("1.TripleDES\t2.MD5\t\t3.SHA1\t\t4.SHA256\t5.SHA384\t6.SHA512\t7.CRC32");
            Console.WriteLine("F.FULL HASH CALC");
            Console.Write("Choose Cryptography: ");
        }

        public static void FullHashCalc(string filePath)
        {
            string hashCode;
            if (filePath == String.Empty)
            {
                Console.Write("\nInput File Path: ");
                filePath = Console.ReadLine();
            }
            Console.WriteLine("|> Hash Code Table");

            //CRC32
            Task t6 = new Task(() => {
                Core.CRC32 crc32 = new Core.CRC32();
                hashCode = crc32.ComputeHashFromFile(filePath);
                Console.WriteLine($"|> CRC32\t|{hashCode}");
            });
            t6.Start();
            //SHA512
            Task t5 = new Task(() => {
                Core.SHA512 sha512 = new Core.SHA512();
                hashCode = sha512.ComputeHashFromFile(filePath);
                Console.WriteLine($"|> SHA512\t|{hashCode}");
            });
            t5.Start();
            //SHA384
            Task t4 = new Task(() => {
                Core.SHA384 sha384 = new Core.SHA384();
                hashCode = sha384.ComputeHashFromFile(filePath);
                Console.WriteLine($"|> SHA384\t|{hashCode}");
            });
            t4.Start();
            //SHA256
            Task t3 = new Task(() => {
                Core.SHA256 sha256 = new Core.SHA256();
                hashCode = sha256.ComputeHashFromFile(filePath);
                Console.WriteLine($"|> SHA256\t|{hashCode}");
            });
            t3.Start();
            //SHA1
            Task t2 = new Task(() => {
                Core.SHA1 sha1 = new Core.SHA1();
                hashCode = sha1.ComputeHashFromFile(filePath);
                Console.WriteLine($"|> SHA1\t\t|{hashCode}");
            });
            t2.Start();
            //MD5
            Task t1 = new Task(() => {
                Core.MD5 md5 = new Core.MD5();
                hashCode = md5.ComputeHashFromFile(filePath);
                Console.WriteLine($"|> MD5\t\t|{hashCode}");
            });
            t1.Start();
            //Wait for tasks finished
            Task.WaitAll(t1, t2, t3, t4, t5, t6);
        }
    }
}