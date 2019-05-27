Imports Newtonsoft.Json


''' <summary>
''' OpenStreet map address
''' </summary>
Public Class OpenStreetMapAddress
    ''' <summary>
    ''' City name
    ''' </summary>
    <JsonProperty("city")>
    Public Property City As String
    ''' <summary>
    ''' County
    ''' </summary>
    <JsonProperty("county")>
    Public Property County As String
    ''' <summary>
    ''' State
    ''' </summary>
    <JsonProperty("state")>
    Public Property State As String
    ''' <summary>
    ''' Country
    ''' </summary>
    <JsonProperty("country")>
    Public Property Country As String
    ''' <summary>
    ''' Country code
    ''' </summary>
    <JsonProperty("country_code")>
    Public Property CountryCode As String
End Class


