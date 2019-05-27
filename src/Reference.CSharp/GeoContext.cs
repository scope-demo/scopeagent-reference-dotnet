using Microsoft.EntityFrameworkCore;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Reference.CSharp
{
    /// <summary>
    /// Geo Context
    /// </summary>
    public class GeoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.DBConnectionString);
        }

        public DbSet<GeoEntity> GeoData { get; set; }
    }
}