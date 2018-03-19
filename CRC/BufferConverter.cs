using System;

namespace CRC
{
    public static class BufferConverter
    {
        public static UInt32[] ToUInt32Array(byte[] buffer)
        {
            UInt32[] output = new UInt32[buffer.Length / 4];
            Buffer.BlockCopy(buffer, 0, output, 0, buffer.Length);
            return output;
        }
    }
}
