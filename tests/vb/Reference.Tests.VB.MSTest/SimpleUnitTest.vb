Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Net.Http
Imports System.Threading.Tasks
' ReSharper disable InconsistentNaming

''' <summary>
''' Simple UnitTest
''' </summary>
<TestClass>
Public Class SimpleUnitTest

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
            Await client.GetAsync("http://localhost")
        End Using
    End Function

    ''' <summary>
    ''' Skipped Test
    ''' </summary>
    <TestMethod>
    <Ignore("Skipped test demo")>
    Public Sub SkipTest()
    End Sub

    ''' <summary>
    ''' Fail Test
    ''' </summary>
    <TestMethod>
    Public Sub FailTest()
        Assert.AreEqual(True, IsPrime(411))
    End Sub

    Private Shared Function IsPrime(value As Integer) As Boolean
        Dim primeI As Integer
        Dim primeFlag = True
        For primeI = 2 To value / 2
            If value Mod primeI = 0 Then
                primeFlag = False
            End If
        Next
        Return primeFlag
    End Function

End Class
