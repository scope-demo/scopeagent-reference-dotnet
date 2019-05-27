using System;
using NUnit.Framework;
using Serilog;

namespace Reference.Tests.CSharp.NUnit
{
    /// <summary>
    /// Serilog UnitTest
    /// </summary>
    public class SerilogUnitTest
    {
        private ILogger _logger;

        /// <summary>
        /// Logger configuration
        /// </summary>
        [SetUp]
        public void StartUp()
        {
            _logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .CreateLogger();
        }

        /// <summary>
        /// Serilog test
        /// </summary>
        [Test]
        public void SerilogExample()
        {
            _logger.Verbose("Verbose in Serilog");
            _logger.Debug("Debug in Serilog");
            _logger.Information("Information in Serilog");
            _logger.Warning("Warning in Serilog");
            _logger.Error("Error in Serilog");
            _logger.Fatal("Fatal in Serilog");

            try
            {
                throw new Exception("Sample exception");
            }
            catch(Exception ex)
            {
                _logger.Error(ex, "Exception error.");
            }

            _logger.Information("Structured log: {@logStruct}", new { Id = 6, Name = "Jacket", Color = "Orange" });
        }
    }
}