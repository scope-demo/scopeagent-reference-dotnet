Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports NLog
Imports NLog.Config

''' <summary>
''' NLog UnitTest
''' </summary>
<TestClass>
Public Class NLogUnitTest
    Private _logger As Logger

    ''' <summary>
    ''' Logger configuration
    ''' </summary>
    <TestInitialize>
    Public Sub StartUp()
        LogManager.Configuration = New LoggingConfiguration()
        _logger = LogManager.GetCurrentClassLogger()
    End Sub

    ''' <summary>
    ''' NLog test
    ''' </summary>
    <TestMethod>
    Public Sub NLogExample()
        _logger.Trace("Trace in NLog")
        _logger.Debug("Debug in NLog")
        _logger.Info("Info in NLog")
        _logger.Warn("Warn in NLog")
        _logger.Error("Error in NLog")
        _logger.Fatal("Fatal in NLog")

        Try
            Throw New Exception("Sample exception")
        Catch ex As Exception
            _logger.Error(ex, "Exception error.")
        End Try

        _logger.Info("Structured log: {logStruct}", New With {.Id = 6, .Name = "Jacket", .Color = "Orange"})
    End Sub
End Class
