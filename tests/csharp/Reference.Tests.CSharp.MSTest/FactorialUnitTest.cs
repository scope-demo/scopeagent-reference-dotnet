using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTracing.Noop;
using OpenTracing.Util;
// ReSharper disable UnusedVariable

namespace Reference.Tests.CSharp.MSTest
{
    /// <summary>
    /// Factorial UnitTest
    /// </summary>
    [TestClass]
    public class FactorialUnitTest
    {
        private ILogger _logger;

        /// <summary>
        /// Initialize test
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            //If no global tracer is registered (not running with scope-run), we register the Noop tracer
            if (!GlobalTracer.IsRegistered())
                GlobalTracer.Register(NoopTracerFactory.Create());

            var loggerFactory = new LoggerFactory()
                // We add the ScopeAgent Logger instrumentation (Automatically added on ASP.NET Core project)
                .AddScopeAgentLogger();

            _logger = loggerFactory.CreateLogger<FactorialUnitTest>();
        }

        /// <summary>
        /// Factorial test
        /// </summary>
        [TestMethod]
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