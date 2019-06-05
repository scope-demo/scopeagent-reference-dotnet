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
        public const string RedisHostName = "rotopia.xyz";
        /// <summary>
        /// DB ConnectionString
        /// </summary>
        public const string DBConnectionString = "Data Source=rotopia.xyz;Initial Catalog=test;Persist Security Info=True;User ID=testUser;Password=testPassw0rd";
        /// <summary>
        /// MongoDB Url
        /// </summary>
        public const string MongoDBUrl = "mongodb://localhost:27017";
        /// <summary>
        /// MongoDB Database
        /// </summary>
        public const string MongoDBDatabase = "Reference";
        /// <summary>
        /// MongoDB Collection
        /// </summary>
        public const string MongoDBCollection = "Geo";
    }
}