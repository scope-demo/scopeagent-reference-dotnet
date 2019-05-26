Imports System.Net.Http
Imports System.Threading.Tasks
Imports NUnit.Framework
' ReSharper disable InconsistentNaming


''' <summary>
''' Simple Integration Test
''' </summary>
Public Class SimpleIntegrationTest

    ''' <summary>
    ''' Simple Http Get OK
    ''' </summary>
    <Test>
    Public Async Function HttpOK() As Task
        Using client = New HttpClient()
            Await client.GetAsync("http://www.google.com")
        End Using
    End Function

    ''' <summary>
    ''' Simple Http Get BadFormat
    ''' </summary>
    <Test>
    Public Async Function HttpBadFormat() As Task
        Using client = New HttpClient()
            Await client.GetAsync("http://www.badUrl.c213")
        End Using
    End Function

    ''' <summary>
    ''' Simple Http Get KO
    ''' </summary>
    <Test>
    Public Async Function HttpKO() As Task
        Using client = New HttpClient()
            Await client.GetAsync("http://localhost")
        End Using
    End Function

End Class

