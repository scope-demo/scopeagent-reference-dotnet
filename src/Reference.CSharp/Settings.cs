// ReSharper disable InconsistentNaming
namespace Reference.CSharp
{
    /// <summary>
    /// Settings
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// Redis HostName
        /// </summary>
        public const string RedisHostName = "redis";
        /// <summary>
        /// DB ConnectionString
        /// </summary>
        public const string DBConnectionString = "Data Source=sqlserver;Initial Catalog=test;Persist Security Info=True;User ID=testUser;Password=testPassw0rd";
        /// <summary>
        /// Postgresql connection string
        /// </summary>
        public const string PostgresConnectionString = "Host=postgres;Port=5432;User ID=testUser;Password=testPassw0rd;Database=test;Pooling=true;";
    }
}