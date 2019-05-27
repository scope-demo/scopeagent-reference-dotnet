using Microsoft.Extensions.Logging;
using NUnit.Framework;
using OpenTracing.Noop;
using OpenTracing.Util;
// ReSharper disable UnusedVariable

namespace Reference.Tests.CSharp.NUnit
{
    /// <summary>
    /// Factorial UnitTest
    /// </summary>
    public class FactorialUnitTest
    {
        private ILogger _logger;

        [SetUp]
        public void Setup()
        {
            //If no global tracer is registered (not running with scope-run), we register the Noop tracer
            if (!GlobalTracer.IsRegistered())
                GlobalTracer.Register(NoopTracerFactory.Create());

            var loggerFactory = new LoggerFactory();
            _logger = loggerFactory.CreateLogger<FactorialUnitTest>();
        }

        /// <summary>
        /// Factorial test
        /// </summary>
        [Test]
        public void FactorialTest()
        {
            Factorial(20);
        }

        /// <summary>
        /// Factorial algorithm
        /// </summary>
        private long Factorial(int number)
        {
            var tracer = GlobalTracer.Instance;
            using (var scope = tracer.BuildSpan("Factorial for: " + number).StartActive())
            {
                long res;
                if (number == 1)
                    res = 1;
                else
                    res = number * Factorial(number - 1);
                _logger.LogInformation("Calculating factorial for: " + number + " = " + res);
                return res;
            }
        }
    }
}