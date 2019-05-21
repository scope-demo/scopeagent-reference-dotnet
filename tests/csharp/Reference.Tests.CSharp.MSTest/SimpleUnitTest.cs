using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
// ReSharper disable InconsistentNaming

namespace Reference.Tests.CSharp.MSTest
{
    /// <summary>
    /// Simple UnitTest
    /// </summary>
    [TestClass]
    public class SimpleUnitTest
    {
        /// <summary>
        /// Simple Http Get OK
        /// </summary>
        [TestMethod]
        public async Task HttpOK()
        {
            using (var client = new HttpClient())
                await client.GetAsync("http://www.google.com");
        }

        /// <summary>
        /// Simple Http Get BadFormat
        /// </summary>
        [TestMethod]
        public async Task HttpBadFormat()
        {
            using (var client = new HttpClient())
                await client.GetAsync("http://www.badUrl.c213");
        }

        /// <summary>
        /// Simple Http Get KO
        /// </summary>
        [TestMethod]
        public async Task HttpKO()
        {
            using (var client = new HttpClient())
                await client.GetAsync("http://localhost");
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