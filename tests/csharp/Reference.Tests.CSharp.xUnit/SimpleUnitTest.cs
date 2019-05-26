using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
// ReSharper disable InconsistentNaming
// ReSharper disable xUnit1004

namespace Reference.Tests.CSharp.xUnit
{
    /// <summary>
    /// Simple Unit Test
    /// </summary>
    public class SimpleUnitTest
    {
        /// <summary>
        /// Skipped Test
        /// </summary>
        [Fact(Skip = "Skipped test demo")]
        public void SkipTest()
        {
        }

        /// <summary>
        /// Fail Test
        /// </summary>
        [Fact]
        public void FailTest()
        {
            Assert.True(IsPrime(411));

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