using Microsoft.EntityFrameworkCore;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Reference.CSharp
{
    /// <summary>
    /// Geo Context
    /// </summary>
    public class GeoContext : DbContext
    {
        private readonly DBServerType dbServerType;

        public GeoContext(DBServerType databaseType)
        {
            dbServerType = databaseType;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            switch (dbServerType)
            {
                case DBServerType.SqlServer:
                    optionsBuilder.UseSqlServer(Settings.DBConnectionString);
                    break;
                case DBServerType.Postgres:
                    optionsBuilder.UseNpgsql(Settings.PostgresConnectionString);
                    break;
                case DBServerType.MySql:
                    optionsBuilder.UseMySql(Settings.MySqlConnectionString);
                    break;
            }
        }

        public DbSet<GeoEntity> GeoData { get; set; }
    }
}