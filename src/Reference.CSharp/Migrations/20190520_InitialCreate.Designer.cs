using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Reference.CSharp.Migrations
{
    [DbContext(typeof(GeoContext))]
    [Migration("20190520_InitialCreate")]
    public partial class InitialCreate : Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Reference.GeoData", b =>
            {
                b.Property<Guid>("Uuid");
                    //.ValueGeneratedOnAdd()
                    //.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
                b.Property<double>("Latitude");
                b.Property<double>("Longitude");
                b.Property<long>("PlaceId");
                b.Property<string>("DisplayName");
                b.Property<string>("City");
                b.Property<string>("County");
                b.Property<string>("State");
                b.Property<string>("Country");
                b.Property<string>("CountryCode");

                b.HasKey("Uuid");

                b.ToTable("GeoData");
            });

#pragma warning restore 612, 618
        }
    }
}