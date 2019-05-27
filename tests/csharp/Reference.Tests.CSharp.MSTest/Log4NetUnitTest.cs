using System;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable InconsistentNaming

namespace Reference.Tests.CSharp.MSTest
{
    /// <summary>
    /// log4net UnitTest
    /// </summary>
    [TestClass]
    public class Log4NetUnitTest
    {
        private ILog _logger;

        /// <summary>
        /// Logger configuration
        /// </summary>
        [TestInitialize]
        public void StartUp()
        {
            _logger = LogManager.GetLogger(typeof(Log4NetUnitTest));
        }

        /// <summary>
        /// log4net test
        /// </summary>
        [TestMethod]
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