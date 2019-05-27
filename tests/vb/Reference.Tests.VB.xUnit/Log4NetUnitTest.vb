Imports log4net
Imports Xunit
' ReSharper disable once InconsistentNaming

''' <summary>
''' log4net UnitTest
''' </summary>
Public Class Log4NetUnitTest
    Private ReadOnly _logger As ILog

    ''' <summary>
    ''' log4net UnitTest .ctor
    ''' </summary>
    Public Sub New()
        _logger = LogManager.GetLogger(GetType(Log4NetUnitTest))
    End Sub

    ''' <summary>
    ''' log4net test
    ''' </summary>
    <Fact>
    Public Sub log4netExample()
        _logger.Debug("Debug in log4net")
        _logger.Info("Info in log4net")
        _logger.Warn("Warn in log4net")
        _logger.Error("Error in log4net")
        _logger.Fatal("Fatal in log4net")

        Try
            Throw New Exception("Sample exception")
        Catch ex As Exception
            _logger.Error("Exception error.", ex)
        End Try

    End Sub

End Class