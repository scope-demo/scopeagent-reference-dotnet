Imports Microsoft.EntityFrameworkCore


''' <summary>
''' Geo Context
''' </summary>
Public Class GeoContext
    Inherits DbContext

    Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
        optionsBuilder.UseSqlServer(Settings.DBConnectionString)
    End Sub

    Public Property GeoData As DbSet(Of GeoEntity)
End Class


