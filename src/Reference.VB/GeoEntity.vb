Imports System.ComponentModel.DataAnnotations

''' <summary>
''' Geo Entity
''' </summary>
Public Class GeoEntity
    ''' <summary>
    ''' UUID
    ''' </summary>
    <Key>
    Public Property Uuid As Guid
    ''' <summary>
    ''' Latitude
    ''' </summary>
    Public Property Latitude As Double
    ''' <summary>
    ''' Longitude
    ''' </summary>
    Public Property Longitude As Double
    ''' <summary>
    ''' Place Id
    ''' </summary>
    Public Property PlaceId As Long
    ''' <summary>
    ''' Display name
    ''' </summary>
    Public Property DisplayName As String
    ''' <summary>
    ''' City name
    ''' </summary>
    Public Property City As String
    ''' <summary>
    ''' County
    ''' </summary>
    Public Property County As String
    ''' <summary>
    ''' State
    ''' </summary>
    Public Property State As String
    ''' <summary>
    ''' Country
    ''' </summary>
    Public Property Country As String
    ''' <summary>
    ''' Country code
    ''' </summary>
    Public Property CountryCode As String
End Class


