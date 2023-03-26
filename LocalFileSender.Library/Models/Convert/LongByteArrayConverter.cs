using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LocalFileSender.Library.Models.Convert
{
    public static class LongByteArrayConverter
    {
        public static byte[] Convert(long value)
        {
            byte[] bytes = new byte[8];
            bytes[0] = (byte)(value & 0xFF);
            bytes[1] = (byte)((value >> 8) & 0xFF);
            bytes[2] = (byte)((value >> 16) & 0xFF);
            bytes[3] = (byte)((value >> 24) & 0xFF);
            bytes[4] = (byte)((value >> 32) & 0xFF);
            bytes[5] = (byte)((value >> 40) & 0xFF);
            bytes[6] = (byte)((value >> 48) & 0xFF);
            bytes[7] = (byte)((value >> 56) & 0xFF);
            return bytes;
        }

        public static long Convert(byte[] bytes)
        {
            if (bytes.Length != 8)
                throw new ArgumentException("bytes should be byte[8]");

            return bytes[0] +
                ((long)bytes[1] << 8) +
                ((long)bytes[2] << 16) +
                ((long)bytes[3] << 24) +
                ((long)bytes[4] << 32) +
                ((long)bytes[5] << 40) +
                ((long)bytes[6] << 48) +
                ((long)bytes[7] << 56);
        }
    }
}
