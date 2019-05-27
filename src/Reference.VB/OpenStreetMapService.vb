Imports System.Net.Http
Imports Newtonsoft.Json


''' <summary>
''' OpenStreet map service
''' </summary>
Public Class OpenStreetMapService
    Private Const ServiceUrl As String = "https://nominatim.openstreetmap.org/reverse?format=json&lat={0}&lon={1}&zoom=18&addressdetails=1"

    ''' <summary>
    ''' Get OpenStreet Map data
    ''' </summary>
    ''' <param name="geoPoint">GeoPoint instance</param>
    ''' <returns>OpenStreetMapItem instance</returns>
    Public Async Function GetOpenStreetMapAsync(geoPoint As GeoPoint) As Task(Of OpenStreetMapItem)
        Using client = New HttpClient()
            client.DefaultRequestHeaders.UserAgent.TryParseAdd("Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.158 Safari/537.36 Vivaldi/2.5.1525.43")
            client.DefaultRequestHeaders.TryAddWithoutValidation(":authority", "nominatim.openstreetmap.org")
            client.DefaultRequestHeaders.TryAddWithoutValidation(":method", "GET")

            Dim response As HttpResponseMessage = Await client.GetAsync(String.Format(ServiceUrl, geoPoint.Latitude, geoPoint.Longitude).Replace(",", "."))
            If Not response.IsSuccessStatusCode Then
                Throw New Exception("Error getting the OpenStreetMap")
            End If
            Dim jsonData As String = Await response.Content.ReadAsStringAsync()
            Return JsonConvert.DeserializeObject(Of OpenStreetMapItem)(jsonData)
        End Using
    End Function

End Class

