using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteCrypt.Core
{
    /// <summary>
    /// Reference: https://www.cnblogs.com/clso/archive/2010/11/29/1891082.html
    /// </summary>
    public class CRC32 : Hash
    {
        public override string ComputeHashFromFile(string filePath)
        {
            try
            {
                FileStream fs = File.OpenRead(filePath);
                long fsLength = fs.Length;
                for (long i = 0; i < fsLength; i++)
                    _value = Table[(((byte)(_value)) ^ fs.ReadByte())] ^ (_value >> 8);
                uint result = _value ^ 0xFFFFFFFF;
                return String.Format("{0:x}", result);
            }
            catch (Exception e)
            {
                return "\nERROR: " + e.Message;
            }
        }

        public override string ComputeHashFromText(string text)
        {
            try
            {
                byte[] textBytes = Encoding.UTF8.GetBytes(text);
                uint result = this.CalculateDigest(textBytes, 0, textBytes.Length);
                return String.Format("{0:x}", result);
            }
            catch (Exception e)
            {
                return "\nERROR: " + e.Message;
            }
        }

        public readonly uint[] Table;

        public CRC32()
        {
            Table = new uint[256];
            const uint kPoly = 0xEDB88320;
            for (uint i = 0; i < 256; i++)
            {
                uint r = i;
                for (int j = 0; j < 8; j++)
                    if ((r & 1) != 0)
                        r = (r >> 1) ^ kPoly;
                    else
                        r >>= 1;
                Table[i] = r;
            }
        }

        private uint _value = 0xFFFFFFFF;

        private void UpdateByte(byte b) { _value = Table[(((byte)(_value)) ^ b)] ^ (_value >> 8); }

        private void Update(byte[] data, long offset, long size)
        {
            for (long i = 0; i < size; i++)
                _value = Table[((byte)_value) ^ data[offset + i]] ^ (_value >> 8);

        }

        private uint GetDigest() { return _value ^ 0xFFFFFFFF; }

        private uint CalculateDigest(byte[] data, long offset, long size)
        {
            Update(data, offset, size);
            return GetDigest();
        }
    }
}
