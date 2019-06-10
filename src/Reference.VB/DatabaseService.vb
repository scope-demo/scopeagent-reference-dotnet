Imports Microsoft.EntityFrameworkCore
' ReSharper disable UnusedMember.Global

''' <summary>
''' Database service
''' </summary>
Public Class DatabaseService
    Implements IPersistentData

    ''' <inheritdoc />
    Public Async Function EnsureMigrationAsync() As Task Implements IPersistentData.EnsureMigrationAsync
        Using context = New GeoContext()
            Await context.Database.MigrateAsync()
        End Using
    End Function

    ''' <inheritdoc />
    Public Async Function SaveDataAsync(geoPoint As GeoPoint, item As OpenStreetMapItem) As Task(Of Boolean) Implements IPersistentData.SaveDataAsync
        Using context = New GeoContext()
            Dim entity = Await context.GeoData.FindAsync(geoPoint.Uuid)
            If entity IsNot Nothing Then
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

            Await context.GeoData.AddAsync(entity)
            Return (Await context.SaveChangesAsync()) > 0
        End Using
    End Function

    ''' <inheritdoc />
    Public Async Function GetAllAsync() As Task(Of List(Of (GeoPoint As GeoPoint, StreetMap As OpenStreetMapItem))) Implements IPersistentData.GetAllAsync
        Dim lstResponse = New List(Of (GeoPoint As GeoPoint, StreetMap As OpenStreetMapItem))
        Using context = New GeoContext()
            Dim data = Await context.GeoData.ToArrayAsync()
            For Each item As GeoEntity In data
                Dim geoPoint = New GeoPoint() With {
                        .Uuid = item.Uuid,
                        .Latitude = item.Latitude,
                        .Longitude = item.Longitude
                        }
                Dim streetMap = New OpenStreetMapItem() With {
                        .PlaceId = item.PlaceId,
                        .DisplayName = item.DisplayName,
                        .Address = New OpenStreetMapAddress() With {
                            .City = item.City,
                            .Country = item.Country,
                            .CountryCode = item.CountryCode,
                            .County = item.County,
                            .State = item.State
                        }
                }
                lstResponse.Add((geoPoint, streetMap))
            Next
        End Using
        Return lstResponse
    End Function

End Class


