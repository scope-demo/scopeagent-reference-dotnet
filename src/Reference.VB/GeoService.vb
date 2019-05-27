Imports System.Net.Http
Imports Newtonsoft.Json


''' <summary>
''' Geo service
''' </summary>
Public Class GeoService
    Private Const ServiceUrl As String = "http://flask-example-project.codescope.com:8000/car"

    ''' <summary>
    ''' Get GeoPoint
    ''' </summary>
    ''' <param name="id">Identifier</param>
    ''' <returns>GeoPoint instance</returns>
    Public Async Function GetGeoPointAsync(id As String) As Task(Of GeoPoint)
        Using client = New HttpClient()
            Dim response As HttpResponseMessage = Await client.GetAsync($"{ServiceUrl}/{id}")
            If Not response.IsSuccessStatusCode Then
                Throw New Exception("Error getting the GeoPoint")
            End If
            Dim jsonData As String = Await response.Content.ReadAsStringAsync()
            Return JsonConvert.DeserializeObject(Of GeoPoint)(jsonData)
        End Using
    End Function

End Class

