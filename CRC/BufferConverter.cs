using System;

namespace CRC
{
    public static class BufferConverter
    {
        /// <summary>
        /// Конвертор из массива byte в массив uint
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static UInt32[] ToUInt32Array(byte[] buffer)
        {
            UInt32[] output = new UInt32[buffer.Length / 4];
            Buffer.BlockCopy(buffer, 0, output, 0, buffer.Length);
            return output;
        }
    }
}
