Imports Microsoft.EntityFrameworkCore

''' <summary>
''' Geo Context
''' </summary>
Public Class GeoContext
    Inherits DbContext

    Private ReadOnly dbServerType As DBServerType

    Public Sub New(databaseType As DBServerType)
        dbServerType = databaseType
    End Sub

    Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
        Select Case dbServerType
            Case DBServerType.SqlServer
                optionsBuilder.UseSqlServer(Settings.DBConnectionString)
            Case DBServerType.Postgres
                optionsBuilder.UseNpgsql(Settings.PostgresConnectionString)
        End Select
    End Sub

    Public Property GeoData As DbSet(Of GeoEntity)
End Class
