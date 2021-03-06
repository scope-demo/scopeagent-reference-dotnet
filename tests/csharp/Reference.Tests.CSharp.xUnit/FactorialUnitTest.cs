﻿using Microsoft.Extensions.Logging;
using OpenTracing.Noop;
using OpenTracing.Util;
using Xunit;
// ReSharper disable UnusedVariable

namespace Reference.Tests.CSharp.xUnit
{
    /// <summary>
    /// Factorial UnitTest
    /// </summary>
    public class FactorialUnitTest
    {
        private readonly ILogger _logger;

        public FactorialUnitTest()
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
        [Fact]
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
