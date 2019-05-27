Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Infrastructure
Imports Microsoft.EntityFrameworkCore.Metadata
Imports Microsoft.EntityFrameworkCore.Metadata.Builders
Imports System

Namespace Migrations

    ''' <summary>
    ''' Geo Context Model Snapshot
    ''' </summary>
    <DbContext(GetType(GeoContext))>
    Public Class GeoContextModelSnapshot
        Inherits ModelSnapshot

        Protected Overrides Sub BuildModel(modelBuilder As ModelBuilder)

            modelBuilder _
            .HasAnnotation("ProductVersion", "2.2.3-servicing-35854") _
            .HasAnnotation("Relational:MaxIdentifierLength", 128) _
            .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)

            modelBuilder.Entity("Reference.GeoData",
                                Sub(entity As EntityTypeBuilder)
                                    entity.Property(Of Guid)("Uuid").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                                    entity.Property(Of Double)("Latitude")
                                    entity.Property(Of Double)("Longitude")
                                    entity.Property(Of Long)("PlaceId")
                                    entity.Property(Of String)("DisplayName")
                                    entity.Property(Of String)("City")
                                    entity.Property(Of String)("County")
                                    entity.Property(Of String)("State")
                                    entity.Property(Of String)("Country")
                                    entity.Property(Of String)("CountryCode")

                                    entity.HasKey("Uuid")

                                    entity.ToTable("GeoData")
                                End Sub)

        End Sub

    End Class

End Namespace
