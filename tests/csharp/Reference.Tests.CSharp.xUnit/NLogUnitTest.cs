using System;
using Xunit;
using NLog;
using NLog.Config;

namespace Reference.Tests.CSharp.xUnit
{
    /// <summary>
    /// NLog UnitTest
    /// </summary>
    public class NLogUnitTest
    {
        private readonly Logger _logger;

        /// <summary>
        /// NLog UnitTest
        /// </summary>
        public NLogUnitTest()
        {
            LogManager.Configuration = new LoggingConfiguration();
            _logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// NLog test
        /// </summary>
        [Fact]
        public void NLogExample()
        {
            _logger.Trace("Trace in NLog");
            _logger.Debug("Debug in NLog");
            _logger.Info("Info in NLog");
            _logger.Warn("Warn in NLog");
            _logger.Error("Error in NLog");
            _logger.Fatal("Fatal in NLog");

            try
            {
                throw new Exception("Sample exception");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Exception error.");
            }

            _logger.Info("Structured log: {logStruct}", new { Id = 6, Name = "Jacket", Color = "Orange" });
        }
    }
}