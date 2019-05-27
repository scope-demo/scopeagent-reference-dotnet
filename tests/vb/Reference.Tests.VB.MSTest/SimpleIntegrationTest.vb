Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Net.Http
Imports System.Threading.Tasks
' ReSharper disable InconsistentNaming

''' <summary>
''' Simple Integration Test
''' </summary>
<TestClass>
Public Class SimpleIntegrationTest

    ''' <summary>
    ''' Simple Http Get OK
    ''' </summary>
    <TestMethod>
    Public Async Function HttpOK() As Task
        Using client = New HttpClient()
            Await client.GetAsync("http://www.google.com")
        End Using
    End Function

    ''' <summary>
    ''' Simple Http Get BadFormat
    ''' </summary>
    <TestMethod>
    Public Async Function HttpBadFormat() As Task
        Using client = New HttpClient()
            Await client.GetAsync("http://www.badUrl.c213")
        End Using
    End Function

    ''' <summary>
    ''' Simple Http Get KO
    ''' </summary>
    <TestMethod>
    Public Async Function HttpKO() As Task
        Using client = New HttpClient()
            Await client.GetAsync("http://localhost:24555")
        End Using
    End Function

End Class
