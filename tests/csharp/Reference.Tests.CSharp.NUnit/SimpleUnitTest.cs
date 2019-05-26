using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
// ReSharper disable InconsistentNaming

namespace Reference.Tests.CSharp.NUnit
{
    /// <summary>
    /// Simple Unit Test
    /// </summary>
    public class SimpleUnitTest
    {
        /// <summary>
        /// Skipped Test
        /// </summary>
        [Test]
        [Ignore("Skipped test demo")]
        public void SkipTest()
        {
        }

        /// <summary>
        /// Fail Test
        /// </summary>
        [Test]
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
