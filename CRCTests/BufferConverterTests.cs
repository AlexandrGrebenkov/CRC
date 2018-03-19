using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CRC.Tests
{
    [TestClass()]
    public class BufferConverterTests
    {
        [TestMethod()]
        public void ToUInt32ArrayTest()
        {
            byte[] byteBuffer = new byte[] { 0x34, 0x33, 0x32, 0x31, 0x38, 0x37, 0x36, 0x35 };//Исходный буфер
            UInt32[] buffer = new UInt32[] { 0x31323334, 0x35363738 };//то, что должно получиться

            var outputBuffer = BufferConverter.ToUInt32Array(byteBuffer);
            CollectionAssert.AreEqual(buffer, outputBuffer);
        }
    }
}