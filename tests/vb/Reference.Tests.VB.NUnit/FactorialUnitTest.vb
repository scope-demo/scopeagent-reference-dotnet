Imports Microsoft.Extensions.Logging
Imports NUnit.Framework
Imports OpenTracing.Noop
Imports OpenTracing.Util
' ReSharper disable UnusedVariable

''' <summary>
''' Factorial UnitTest
''' </summary>
Public Class FactorialUnitTest

    Private _logger As ILogger

    ''' <summary>
    ''' Initialize test
    ''' </summary>
    <SetUp>
    Public Sub Init()

        'If no global tracer is registered (not running with scope-run), we register the Noop tracer
        If Not GlobalTracer.IsRegistered() Then
            GlobalTracer.Register(NoopTracerFactory.Create())
        End If

        Dim loggerFactory = New LoggerFactory()
        _logger = loggerFactory.CreateLogger(Of FactorialUnitTest)()

    End Sub

    ''' <summary>
    ''' Factorial test
    ''' </summary>
    <Test>
    Sub FactorialTest()
        Factorial(20L)
    End Sub

    ''' <summary>
    ''' Factorial algorithm
    ''' </summary>
    Private Function Factorial(number As Long) As Long
        Dim tracer = GlobalTracer.Instance
        Using scope As OpenTracing.IScope = tracer.BuildSpan("Factorial for: " & number).StartActive()
            Dim res As Long
            If number = 1 Then
                res = 1
            Else
                res = number * Factorial(number - 1)
            End If
            _logger.LogInformation("Calculating factorial for: " & number & " = " & res)
            Return res
        End Using
    End Function

End Class

