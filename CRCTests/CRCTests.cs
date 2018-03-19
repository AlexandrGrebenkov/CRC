using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRC;
using System;

namespace CRC.Tests
{
    [TestClass()]
    public class CRCTests
    {
        [TestMethod()]
        public void CRC32Test()
        {
            UInt32[] buffer = new UInt32[] { 0x31323334, 0x35363738 };
            uint poly = 0x04C11DB7;
            uint initValue = 0xFFFFFFFF;
            uint result;

            //CRC-32/MPEG-2
            poly = 0x04C11DB7;
            initValue = 0xFFFFFFFF;
            result = 0x49E3C2FB;
            Assert.AreEqual(result, CRC.CRC32(buffer, poly, initValue), "CRC-32/MPEG-2");

            //CRC-32Q
            poly = 0x814141AB;
            initValue = 0x00000000;
            result = 0xA266867F;
            Assert.AreEqual(result, CRC.CRC32(buffer, poly, initValue), "CRC-32Q");
        }

        [TestMethod()]
        public void CRC32TestFromByteArray()
        {
            byte[] byteBuffer = new byte[] { 0x34, 0x33, 0x32, 0x31, 0x38, 0x37, 0x36, 0x35 };
            UInt32[] buffer = BufferConverter.ToUInt32Array(byteBuffer);

            uint poly = 0x04C11DB7;
            uint initValue = 0xFFFFFFFF;
            uint result;

            //CRC-32/MPEG-2
            poly = 0x04C11DB7;
            initValue = 0xFFFFFFFF;
            result = 0x49E3C2FB;
            Assert.AreEqual(result, CRC.CRC32(buffer, poly, initValue), "CRC-32/MPEG-2");

            //CRC-32Q
            poly = 0x814141AB;
            initValue = 0x00000000;
            result = 0xA266867F;
            Assert.AreEqual(result, CRC.CRC32(buffer, poly, initValue), "CRC-32Q");
        }

        [TestMethod()]
        public void CRC32_TableTest()
        {
            UInt32[] buffer = new UInt32[] { 0x31323334, 0x35363738 };

            uint result = 0x49E3C2FB;
            Assert.AreEqual(result, CRC.CRC32_Table(buffer), "CRC-32/MPEG-2");
        }
    }
}