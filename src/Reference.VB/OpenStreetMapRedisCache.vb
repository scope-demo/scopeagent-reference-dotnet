Imports Newtonsoft.Json
Imports StackExchange.Redis


''' <summary>
''' OpenStreet Map Redis cache
''' </summary>
Public Class OpenStreetMapRedisCache
    Private ReadOnly _connectionMultiplexer As Task(Of ConnectionMultiplexer)

    ''' <summary>
    ''' OpenStreet Map Redis cache .ctor
    ''' </summary>
    Public Sub New()
        _connectionMultiplexer = ConnectionMultiplexer.ConnectAsync(Settings.RedisHostName)
    End Sub

    ''' <summary>
    ''' Get OpenStreetMap item from cache
    ''' </summary>
    ''' <param name="id">Identifier</param>
    ''' <returns>OpenStreetMap item value</returns>
    Public Async Function GetOpenStreetMapAsync(id As String) As Task(Of OpenStreetMapItem)
        Dim conn = Await _connectionMultiplexer
        Dim db = conn.GetDatabase()

        Dim resValue = Await db.StringGetAsync("OSM-" & id)
        If resValue.HasValue Then
            Return JsonConvert.DeserializeObject(Of OpenStreetMapItem)(resValue)
        End If
        Return Nothing
    End Function

    ''' <summary>
    ''' Save OpenStreetMap item to cache
    ''' </summary>
    ''' <param name="id">Identifier</param>
    ''' <param name="item">OpenStreetMap item value</param>
    ''' <returns>Save Task</returns>
    Public Async Function SetOpenStreetMapAsync(id As String, item As OpenStreetMapItem) As Task
        Dim conn = Await _connectionMultiplexer
        Dim db = conn.GetDatabase()

        Dim jsonData = JsonConvert.SerializeObject(item)
        Await db.StringSetAsync("OSM-" & id, jsonData)
    End Function

    ''' <summary>
    ''' Delete key
    ''' </summary>
    ''' <param name="id">Identifier</param>
    ''' <returns>Delete Task</returns>
    Public Async Function DeleteAsync(id As String) As Task
        Dim conn = Await _connectionMultiplexer
        Dim db = conn.GetDatabase()
        Await db.KeyDeleteAsync("OSM-" & id)
    End Function

End Class


