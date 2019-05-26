using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
// ReSharper disable InconsistentNaming
// ReSharper disable xUnit1004

namespace Reference.Tests.CSharp.xUnit
{
    /// <summary>
    /// Simple Integration Test
    /// </summary>
    public class SimpleIntegrationTest
    {
        /// <summary>
        /// Simple Http Get OK
        /// </summary>
        [Fact]
        public async Task HttpOK()
        {
            using (var client = new HttpClient())
                await client.GetAsync("http://www.google.com");
        }

        /// <summary>
        /// Simple Http Get BadFormat
        /// </summary>
        [Fact]
        public async Task HttpBadFormat()
        {
            using (var client = new HttpClient())
                await client.GetAsync("http://www.badUrl.c213");
        }

        /// <summary>
        /// Simple Http Get KO
        /// </summary>
        [Fact]
        public async Task HttpKO()
        {
            using (var client = new HttpClient())
                await client.GetAsync("http://localhost");
        }
    }
}