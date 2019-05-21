using Newtonsoft.Json;
using StackExchange.Redis;
using System.Threading.Tasks;

namespace Reference.CSharp
{
    /// <summary>
    /// GeoService Redis cache
    /// </summary>
    public class GeoServiceRedisCache
    {
        private readonly Task<ConnectionMultiplexer> _connectionMultiplexer;

        /// <summary>
        /// GeoService Redis cache .ctor
        /// </summary>
        public GeoServiceRedisCache()
        {
            _connectionMultiplexer = ConnectionMultiplexer.ConnectAsync(Settings.RedisHostName);
        }

        /// <summary>
        /// Get GeoPoint value from cache
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>GeoPoint instance</returns>
        public async Task<GeoPoint> GetGeoPointAsync(string id)
        {
            var conn = await _connectionMultiplexer;
            var db = conn.GetDatabase();

            var resValue = await db.StringGetAsync("GEO-" + id);
            return resValue.HasValue ? JsonConvert.DeserializeObject<GeoPoint>(resValue) : null;
        }
        /// <summary>
        /// Set GeoPoint value to cache
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <param name="geoPoint">GeoPoint value</param>
        /// <returns>Save Task</returns>
        public async Task SetGeoPointAsync(string id, GeoPoint geoPoint)
        {
            var conn = await _connectionMultiplexer;
            var db = conn.GetDatabase();

            var jsonData = JsonConvert.SerializeObject(geoPoint);
            await db.StringSetAsync("GEO-" + id, jsonData);
        }
        /// <summary>
        /// Delete key
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Delete Task</returns>
        public async Task DeleteAsync(string id)
        {
            var conn = await _connectionMultiplexer;
            var db = conn.GetDatabase();
            await db.KeyDeleteAsync("GEO-" + id);
        }
    }
}