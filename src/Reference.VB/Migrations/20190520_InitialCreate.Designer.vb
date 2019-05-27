Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Infrastructure
Imports Microsoft.EntityFrameworkCore.Metadata
Imports Microsoft.EntityFrameworkCore.Metadata.Builders
Imports Microsoft.EntityFrameworkCore.Migrations

Namespace Migrations
    <DbContext(GetType(GeoContext))>
    <Migration("20190520_InitialCreate")>
    Partial Public Class InitialCreate
        Inherits Migration

        Protected Overrides Sub BuildTargetModel(modelBuilder As ModelBuilder)

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
