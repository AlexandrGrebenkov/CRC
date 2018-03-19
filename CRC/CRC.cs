using System;

namespace CRC
{
    /// <summary>Расчёт CRC</summary>
    /// http://sunshine2k.de/coding/javascript/crc/crc_js.html
    /// http://crccalc.com/
    static public class CRC
    {
        /// <summary>
        /// Метод расчёта CRC32 с заданным полиномом и начальным значением
        /// </summary>
        /// <param name="Buf">Расчётный массив</param>
        /// <param name="polynomial">Полином</param>
        /// <param name="initialValue">Начальное значение</param>
        /// <returns>CRC32</returns>
        public static UInt32 CRC32(UInt32[] Buf, UInt32 polynomial = 0x04C11DB7, UInt32 initialValue = 0xFFFFFFFF)
        {
            return CRC32(Buf, 0, Buf.Length, polynomial, initialValue);
        }

        /// <summary>
        /// Метод расчёта CRC32
        /// </summary>
        /// <param name="Buf">Расчётный массив</param>
        /// <param name="offset">Индекс первого байта в массиве</param>
        /// <param name="lenth">Расчётная длина</param>
        /// <param name="polynomial">Полином</param>
        /// <param name="initialValue">Начальное значение</param>
        /// <returns></returns>
        public static UInt32 CRC32(UInt32[] Buf, int offset, int lenth, UInt32 polynomial = 0x04C11DB7, UInt32 initialValue = 0xFFFFFFFF)
        {
            if (Buf == null)
                throw new ArgumentNullException(nameof(Buf), "Нет массива!");
            if ((offset < 0) | (lenth <= 0))
                throw new ArgumentException("Неправильно задана длина или смещение");
            if (offset + lenth > Buf.Length)
                throw new ArgumentOutOfRangeException("Расчётная длина превышает длину массива");

            UInt32 CRC = initialValue;

            for (int i = 0; i < Buf.Length; i++)
            {
                CRC ^= Buf[i];
                for (int j = 0; j < 32; j++)
                {
                    if ((CRC & (1 << 31)) != 0)
                        CRC = (CRC << 1) ^ polynomial;
                    else
                        CRC = CRC << 1;
                }
            }

            return CRC;
        }

        /// <summary>
        /// Табличный метод расчёта CRC32 для polynomial = 0x04C11DB7, initialValue = 0xFFFFFFFF
        /// </summary>
        /// <param name="Buf"></param>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        public static UInt32 CRC32_Table(uint[] Buf, UInt32 initialValue = 0xFFFFFFFF)
        {
            UInt32[] CrcTable = new UInt32[16]
            { //Nibble lookup table for 0x04C11DB7 polynomial
                0x00000000, 0x04C11DB7, 0x09823B6E, 0x0D4326D9,
                0x130476DC, 0x17C56B6B, 0x1A864DB2, 0x1E475005,
                0x2608EDB8, 0x22C9F00F, 0x2F8AD6D6, 0x2B4BCB61,
                0x350C9B64, 0x31CD86D3, 0x3C8EA00A, 0x384FBDBD
            };
            UInt32 _CRC32 = 0;

            bool Flag = true;
            if (Flag)
                _CRC32 = initialValue;

            int i = 0;
            int len = Buf.Length;
            while ((len--) != 0)
            {
                _CRC32 ^= Buf[i++];
                //Process 32-bits, 4 at a time, or 8 rounds
                _CRC32 = (_CRC32 << 4) ^ CrcTable[_CRC32 >> 28]; //Assumes 32-bit reg, masking index to 4-bits
                _CRC32 = (_CRC32 << 4) ^ CrcTable[_CRC32 >> 28]; //0x04C11DB7 Polynomial used in STM32
                _CRC32 = (_CRC32 << 4) ^ CrcTable[_CRC32 >> 28];
                _CRC32 = (_CRC32 << 4) ^ CrcTable[_CRC32 >> 28];
                _CRC32 = (_CRC32 << 4) ^ CrcTable[_CRC32 >> 28];
                _CRC32 = (_CRC32 << 4) ^ CrcTable[_CRC32 >> 28];
                _CRC32 = (_CRC32 << 4) ^ CrcTable[_CRC32 >> 28];
                _CRC32 = (_CRC32 << 4) ^ CrcTable[_CRC32 >> 28];
            }
            return _CRC32;
        }
    }
}
