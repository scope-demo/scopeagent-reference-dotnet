Imports Serilog
Imports Xunit

''' <summary>
''' Serilog UnitTest
''' </summary>
Public Class SerilogUnitTest
    Private ReadOnly _logger As ILogger

    ''' <summary>
    ''' Serilog UnitTest .ctor
    ''' </summary>
    Public Sub New()
        _logger = New LoggerConfiguration() _
            .MinimumLevel.Information() _
            .CreateLogger()
    End Sub

    ''' <summary>
    ''' Serilog test
    ''' </summary>
    <Fact>
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
