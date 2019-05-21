Imports Newtonsoft.Json

''' <summary>
''' OpenStreet Map
''' </summary>
Public Class OpenStreetMapItem
    ''' <summary>
    ''' Place Id
    ''' </summary>
    <JsonProperty("place_id")>
    Public Property PlaceId As Long
    ''' <summary>
    ''' Display name
    ''' </summary>
    <JsonProperty("display_name")>
    Public Property DisplayName As String
    ''' <summary>
    ''' Address
    ''' </summary>
    <JsonProperty("address")>
    Public Property Address As OpenStreetMapAddress
End Class


