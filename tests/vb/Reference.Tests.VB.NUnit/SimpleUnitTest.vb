Imports System.Net.Http
Imports System.Threading.Tasks
Imports NUnit.Framework
' ReSharper disable InconsistentNaming

''' <summary>
''' Simple Unit Test
''' </summary>
Public Class SimpleUnitTest

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

