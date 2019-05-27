using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Threading.Tasks;
// ReSharper disable InconsistentNaming

namespace Reference.Tests.CSharp.MSTest
{
    /// <summary>
    /// Simple Unit Test
    /// </summary>
    [TestClass]
    public class SimpleUnitTest
    {
        /// <summary>
        /// Ok Test
        /// </summary>
        [TestMethod]
        public void OkTest()
        {
            var str01 = "Hello World";
            var str02 = "hello world";

            Assert.IsTrue(string.Equals(str01, str02, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Error test
        /// </summary>
        [TestMethod]
        public void ErrorTest()
        {
            var base64 = Convert.ToBase64String(new byte[] { 0x01, 0x02, 0x03, 0xA0, 0xA1, 0xA2, 0xA3 });
            StackLevel01(base64);
        }
        void StackLevel01(string base64)
        {
            StackLevel02(base64);
        }
        void StackLevel02(string base64)
        {
            StackLevel03(base64);
        }
        void StackLevel03(string base64)
        {
            Convert.FromBase64String(base64.Substring(1));
        }

        /// <summary>
        /// Skipped Test
        /// </summary>
        [TestMethod]
        [Ignore("Skipped test demo")]
        public void SkipTest()
        {
        }

        /// <summary>
        /// Fail Test
        /// </summary>
        [TestMethod]
        public void FailTest()
        {
            Assert.AreEqual(true, IsPrime(411));
            
            bool IsPrime(int value)
            {
                if ((value & 1) == 0)
                    return value == 2;

                for (var i = 3; i * i <= value; i += 2)
                {
                    if (value % i == 0)
                        return false;
                }
                return value != 1;
            }
        }
    }
}