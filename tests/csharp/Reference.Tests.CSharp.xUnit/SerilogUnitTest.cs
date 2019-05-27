using System;
using Xunit;
using Serilog;

namespace Reference.Tests.CSharp.xUnit
{
    /// <summary>
    /// Serilog UnitTest
    /// </summary>
    public class SerilogUnitTest
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Serilog UnitTest .ctor
        /// </summary>
        public SerilogUnitTest()
        {
            _logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .CreateLogger();
        }

        /// <summary>
        /// Serilog test
        /// </summary>
        [Fact]
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