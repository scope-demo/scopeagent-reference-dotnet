using System;
using NUnit.Framework;
using log4net;
// ReSharper disable InconsistentNaming

namespace Reference.Tests.CSharp.NUnit
{
    /// <summary>
    /// log4net UnitTest
    /// </summary>
    public class Log4NetUnitTest
    {
        private ILog _logger;

        /// <summary>
        /// Logger configuration
        /// </summary>
        [SetUp]
        public void StartUp()
        {
            _logger = LogManager.GetLogger(typeof(Log4NetUnitTest));
        }

        /// <summary>
        /// log4net test
        /// </summary>
        [Test]
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