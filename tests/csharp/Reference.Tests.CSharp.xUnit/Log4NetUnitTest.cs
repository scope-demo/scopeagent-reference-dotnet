using System;
using log4net;
using Xunit;
// ReSharper disable InconsistentNaming

namespace Reference.Tests.CSharp.xUnit
{
    /// <summary>
    /// log4net UnitTest
    /// </summary>
    public class Log4NetUnitTest
    {
        private readonly ILog _logger;

        /// <summary>
        /// log4net UnitTest .ctor
        /// </summary>
        public Log4NetUnitTest()
        {
            _logger = LogManager.GetLogger(typeof(Log4NetUnitTest));
        }

        /// <summary>
        /// log4net test
        /// </summary>
        [Fact]
        public void log4netExample()
        {
            _logger.Debug("Debug in log4net");
            _logger.Info("Info in log4net");
            _logger.Warn("Warn in log4net");
            _logger.Error("Error in log4net");
            _logger.Fatal("Fatal in log4net");

            try
            {
                throw new Exception("Sample exception");
            }
            catch (Exception ex)
            {
                _logger.Error("Exception error.", ex);
            }
        }
    }
}