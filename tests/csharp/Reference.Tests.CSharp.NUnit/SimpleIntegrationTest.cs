using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
// ReSharper disable InconsistentNaming

namespace Reference.Tests.CSharp.NUnit
{
    /// <summary>
    /// Simple Integration Test
    /// </summary>
    public class SimpleIntegrationTest
    {
        /// <summary>
        /// Simple Http Get OK
        /// </summary>
        [Test]
        public async Task HttpOK()
        {
            using (var client = new HttpClient())
                await client.GetAsync("http://www.google.com");
        }

        /// <summary>
        /// Simple Http Get BadFormat
        /// </summary>
        [Test]
        public async Task HttpBadFormat()
        {
            using (var client = new HttpClient())
                await client.GetAsync("http://www.badUrl.c213");
        }

        /// <summary>
        /// Simple Http Get KO
        /// </summary>
        [Test]
        public async Task HttpKO()
        {
            using (var client = new HttpClient())
                await client.GetAsync("http://localhost");
        }
    }
}
