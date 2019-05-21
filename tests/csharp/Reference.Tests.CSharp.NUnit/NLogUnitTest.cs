using System;
using NUnit.Framework;
using NLog;
using NLog.Config;

namespace Reference.Tests.CSharp.NUnit
{
    /// <summary>
    /// NLog UnitTest
    /// </summary>
    public class NLogUnitTest
    {
        private Logger _logger;

        /// <summary>
        /// Logger configuration
        /// </summary>
        [SetUp]
        public void StartUp()
        {
            LogManager.Configuration = new LoggingConfiguration();
            _logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// NLog test
        /// </summary>
        [Test]
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