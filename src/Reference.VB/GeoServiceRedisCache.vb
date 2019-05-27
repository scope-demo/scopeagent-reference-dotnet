Imports Newtonsoft.Json
Imports StackExchange.Redis

''' <summary>
''' GeoService Redis cache
''' </summary>
Public Class GeoServiceRedisCache
    Private ReadOnly _connectionMultiplexer As Task(Of ConnectionMultiplexer)

    ''' <summary>
    ''' GeoService Redis cache .ctor
    ''' </summary>
    Public Sub New()
        _connectionMultiplexer = ConnectionMultiplexer.ConnectAsync(Settings.RedisHostName)
    End Sub

    ''' <summary>
    ''' Get GeoPoint value from cache
    ''' </summary>
    ''' <param name="id">Identifier</param>
    ''' <returns>GeoPoint instance</returns>
    Public Async Function GetGeoPointAsync(id As String) As Task(Of GeoPoint)
        Dim conn = Await _connectionMultiplexer
        Dim db = conn.GetDatabase()

        Dim resValue = Await db.StringGetAsync("GEO-" & id)
        If resValue.HasValue Then
            Return JsonConvert.DeserializeObject(Of GeoPoint)(resValue)
        End If
        Return Nothing
    End Function

    ''' <summary>
    ''' Set GeoPoint value to cache
    ''' </summary>
    ''' <param name="id">Identifier</param>
    ''' <param name="geoPoint">GeoPoint value</param>
    ''' <returns>Save Task</returns>
    Public Async Function SetGeoPointAsync(id As String, geoPoint As GeoPoint) As Task
        Dim conn = Await _connectionMultiplexer
        Dim db = conn.GetDatabase()

        Dim jsonData = JsonConvert.SerializeObject(geoPoint)
        Await db.StringSetAsync("GEO-" & id, jsonData)
    End Function

    ''' <summary>
    ''' Delete key
    ''' </summary>
    ''' <param name="id">Identifier</param>
    ''' <returns>Delete Task</returns>
    Public Async Function DeleteAsync(id As String) As Task
        Dim conn = Await _connectionMultiplexer
        Dim db = conn.GetDatabase()
        Await db.KeyDeleteAsync("GEO-" & id)
    End Function

End Class


