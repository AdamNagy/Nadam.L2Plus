using System;
using CshFundemantals;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class RomanNumerals
    {
        [TestMethod]
        public void Convert1()
        {
            string result = 1.ToRoman();
            Assert.AreEqual("I", result);
        }

        [TestMethod]
        public void Convert3()
        {
            string result = 3.ToRoman();
            Assert.AreEqual("III", result);
        }

        [TestMethod]
        public void Convert5()
        {
            string result = 5.ToRoman();
            Assert.AreEqual("V", result);
        }

        [TestMethod]
        public void Convert7()
        {
            string result = 7.ToRoman();
            Assert.AreEqual("VII", result);
        }
    }
}
