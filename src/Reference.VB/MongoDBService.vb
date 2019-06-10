Imports System.Linq.Expressions
Imports MongoDB.Bson.Serialization
Imports MongoDB.Driver

Public Class MongoDBService
    Implements IPersistentData

    Private ReadOnly _database As IMongoDatabase

    Public Sub New()
        BsonClassMap.RegisterClassMap(Of GeoEntity)(Sub(map)
                                                        map.MapIdProperty("Uuid")
                                                        map.MapProperty("Latitude")
                                                        map.MapProperty("Longitude")
                                                        map.MapProperty("PlaceId")
                                                        map.MapProperty("DisplayName")
                                                        map.MapProperty("City")
                                                        map.MapProperty("County")
                                                        map.MapProperty("State")
                                                        map.MapProperty("Country")
                                                        map.MapProperty("CountryCode")
                                                    End Sub)
        Dim client = New MongoClient(Settings.MongoDBUrl)
        _database = client.GetDatabase(Settings.MongoDBDatabase)
    End Sub

    ''' <inheritdoc />
    Public Async Function EnsureMigrationAsync() As Task Implements IPersistentData.EnsureMigrationAsync
        Dim lstCollection = Await (Await _database.ListCollectionNamesAsync()).ToListAsync()
        If (lstCollection.Any(Function(col) col = Settings.MongoDBCollection) = False) Then
            Await _database.CreateCollectionAsync(Settings.MongoDBCollection)
        End If
    End Function

    ''' <inheritdoc />
    Public Async Function SaveDataAsync(geoPoint As GeoPoint, item As OpenStreetMapItem) As Task(Of Boolean) Implements IPersistentData.SaveDataAsync
        Dim geoCollection = _database.GetCollection(Of GeoEntity)(Settings.MongoDBCollection)

        Dim entity = Await (Await geoCollection.FindAsync(Function(i) i.Uuid = geoPoint.Uuid)).FirstOrDefaultAsync()
        If Not entity Is Nothing Then
            Return False
        End If

        entity = New GeoEntity With {
            .Uuid = geoPoint.Uuid,
            .Latitude = geoPoint.Latitude,
            .Longitude = geoPoint.Longitude,
            .PlaceId = item.PlaceId,
            .DisplayName = item.DisplayName,
            .City = item.Address?.City,
            .Country = item.Address?.Country,
            .CountryCode = item.Address?.CountryCode,
            .County = item.Address?.County,
            .State = item.Address?.State
        }

        Await geoCollection.InsertOneAsync(entity)
        Return True
    End Function

    ''' <inheritdoc />
    Public Async Function GetAllAsync() As Task(Of List(Of (GeoPoint As GeoPoint, StreetMap As OpenStreetMapItem))) Implements IPersistentData.GetAllAsync
        Dim geoCollection = _database.GetCollection(Of GeoEntity)(Settings.MongoDBCollection)

        Dim lstResponse = New List(Of (GeoPoint As GeoPoint, StreetMap As OpenStreetMapItem))
        Dim data = Await (Await geoCollection.FindAsync(Function(i) True)).ToListAsync()
        For Each item As GeoEntity In data
            Dim tmpGeoPoint = New GeoPoint With {
                .Uuid = item.Uuid,
                .Latitude = item.Latitude,
                .Longitude = item.Longitude
            }
            Dim tmpMapItem = New OpenStreetMapItem With {
                .PlaceId = item.PlaceId,
                .DisplayName = item.DisplayName,
                .Address = New OpenStreetMapAddress With {
                    .City = item.City,
                    .Country = item.Country,
                    .CountryCode = item.CountryCode,
                    .County = item.County,
                    .State = item.State
                }
            }
            lstResponse.Add((tmpGeoPoint, tmpMapItem))
        Next
        Return lstResponse
    End Function
End Class
