Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Serilog

''' <summary>
''' Serilog UnitTest
''' </summary>
<TestClass>
Public Class SerilogUnitTest
    Private _logger As ILogger

    ''' <summary>
    ''' Logger configuration
    ''' </summary>
    <TestInitialize>
    Public Sub StartUp()
        _logger = New LoggerConfiguration() _
            .MinimumLevel.Information() _
            .CreateLogger()
    End Sub

    ''' <summary>
    ''' Serilog test
    ''' </summary>
    <TestMethod>
    Public Sub SerilogExample()
        _logger.Verbose("Verbose in Serilog")
        _logger.Debug("Debug in Serilog")
        _logger.Information("Information in Serilog")
        _logger.Warning("Warning in Serilog")
        _logger.Error("Error in Serilog")
        _logger.Fatal("Fatal in Serilog")

        Try
            Throw New Exception("Sample exception")
        Catch ex As Exception
            _logger.Error(ex, "Exception error.")
        End Try

        _logger.Information("Structured log: {@logStruct}", New With {.Id = 6, .Name = "Jacket", .Color = "Orange"})
    End Sub

End Class
