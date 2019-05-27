Imports System.Net.Http
Imports System.Threading.Tasks
Imports Xunit
' ReSharper disable InconsistentNaming

''' <summary>
''' Simple Unit Test
''' </summary>
Public Class SimpleUnitTest

    ''' <summary>
    ''' Ok Test
    ''' </summary>
    <Fact>
    Public Sub OkTest()
        Dim str01 = "Hello World"
        Dim str02 = "hello world"

        Assert.Equal(str01, str02, ignoreCase:=True)
    End Sub

    ''' <summary>
    ''' Error test
    ''' </summary>
    <Fact>
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
    <Fact(Skip:="Skipped test demo")>
    Public Sub SkipTest()
    End Sub

    ''' <summary>
    ''' Fail Test
    ''' </summary>
    <Fact>
    Public Sub FailTest()
        Assert.True(IsPrime(411))
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

