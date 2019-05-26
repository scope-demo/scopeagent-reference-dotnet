using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
// ReSharper disable InconsistentNaming

namespace Reference.Tests.CSharp.MSTest
{
    /// <summary>
    /// Simple Integration Test
    /// </summary>
    [TestClass]
    public class SimpleIntegrationTest
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
    }
}