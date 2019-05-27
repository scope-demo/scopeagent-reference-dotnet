Imports System.Net.Http
Imports System.Threading.Tasks
Imports NUnit.Framework
' ReSharper disable InconsistentNaming

''' <summary>
''' Simple Unit Test
''' </summary>
Public Class SimpleUnitTest

    ''' <summary>
    ''' Ok Test
    ''' </summary>
    <Test>
    Public Sub OkTest()
        Dim str01 = "Hello World"
        Dim str02 = "hello world"

        Assert.IsTrue(String.Equals(str01, str02, StringComparison.OrdinalIgnoreCase))
    End Sub

    ''' <summary>
    ''' Error test
    ''' </summary>
    <Test>
    Public Sub ErrorTest()
        Dim base64 = Convert.ToBase64String(New Byte() {1, 2, 3, 10, 11, 12, 13})
        StackLevel01(base64)
    End Sub
    Public Sub StackLevel01(base64 As String)
        StackLevel02(base64)
    End Sub
    Public Sub StackLevel02(base64 As String)
        StackLevel03(base64)
    End Sub
    Public Sub StackLevel03(base64 As String)
        Convert.FromBase64String(base64.Substring(1))
    End Sub

    ''' <summary>
    ''' Skipped Test
    ''' </summary>
    <Test>
    <Ignore("Skipped test demo")>
    Public Sub SkipTest()
    End Sub

    ''' <summary>
    ''' Fail Test
    ''' </summary>
    <Test>
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

