Imports Microsoft.EntityFrameworkCore.Migrations

Namespace Migrations
    Partial Public Class InitialCreate
        Inherits Migration

        Protected Overrides Sub Up(migrationBuilder As MigrationBuilder)

            migrationBuilder.CreateTable(name:="GeoData",
                columns:=Function(table)
                             Return New With {
                                .Uuid = table.Column(Of Guid)(nullable:=False),
                                .Latitude = table.Column(Of Double)(nullable:=True),
                                .Longitude = table.Column(Of Double)(nullable:=True),
                                .PlaceId = table.Column(Of Long)(nullable:=True),
                                .DisplayName = table.Column(Of String)(nullable:=True),
                                .City = table.Column(Of String)(nullable:=True),
                                .County = table.Column(Of String)(nullable:=True),
                                .State = table.Column(Of String)(nullable:=True),
                                .Country = table.Column(Of String)(nullable:=True),
                                .CountryCode = table.Column(Of String)(nullable:=True)
                            }
                         End Function,
                constraints:=Sub(table)
                                 table.PrimaryKey("PK_GeoData", Function(x) x.Uuid)
                             End Sub)

        End Sub

        Protected Overrides Sub Down(migrationBuilder As MigrationBuilder)
            migrationBuilder.DropTable("GeoData")
        End Sub

    End Class

End Namespace
