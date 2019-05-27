Imports System
Imports Newtonsoft.Json


''' <summary>
''' Geo point
''' </summary>
Public Class GeoPoint
    ''' <summary>
    ''' UUID
    ''' </summary>
    <JsonProperty("uuid")>
    Public Property Uuid As Guid
    ''' <summary>
    ''' Latitude
    ''' </summary>
    <JsonProperty("lat")>
    Public Property Latitude As Double
    ''' <summary>
    ''' Longitude
    ''' </summary>
    <JsonProperty("lon")>
    Public Property Longitude As Double
End Class


