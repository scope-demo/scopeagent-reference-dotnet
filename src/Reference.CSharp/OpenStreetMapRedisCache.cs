using Newtonsoft.Json;
using StackExchange.Redis;
using System.Threading.Tasks;

namespace Reference.CSharp
{
    /// <summary>
    /// OpenStreet Map Redis cache
    /// </summary>
    public class OpenStreetMapRedisCache
    {
        private readonly Task<ConnectionMultiplexer> _connectionMultiplexer;

        /// <summary>
        /// OpenStreet Map Redis cache .ctor
        /// </summary>
        public OpenStreetMapRedisCache()
        {
            _connectionMultiplexer = ConnectionMultiplexer.ConnectAsync(Settings.RedisHostName);
        }

        /// <summary>
        /// Get OpenStreetMap item from cache
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>OpenStreetMap item value</returns>
        public async Task<OpenStreetMapItem> GetOpenStreetMapAsync(string id)
        {
            var conn = await _connectionMultiplexer;
            var db = conn.GetDatabase();

            var resValue = await db.StringGetAsync("OSM-" + id);
            return resValue.HasValue ? JsonConvert.DeserializeObject<OpenStreetMapItem>(resValue) : null;
        }
        /// <summary>
        /// Save OpenStreetMap item to cache
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <param name="item">OpenStreetMap item value</param>
        /// <returns>Save Task</returns>
        public async Task SetOpenStreetMapAsync(string id, OpenStreetMapItem item)
        {
            var conn = await _connectionMultiplexer;
            var db = conn.GetDatabase();

            var jsonData = JsonConvert.SerializeObject(item);
            await db.StringSetAsync("OSM-" + id, jsonData);
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
            await db.KeyDeleteAsync("OSM-" + id);
        }
    }
}