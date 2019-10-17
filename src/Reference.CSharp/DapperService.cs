using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
// ReSharper disable UnusedMember.Global

namespace Reference.CSharp
{
    public class DapperService
    {
        /// <summary>
        /// Ensure migration
        /// </summary>
        /// <returns>Migration task</returns>
        public async Task EnsureMigrationAsync()
        {
            var dbService = new DatabaseService();
            await dbService.EnsureMigrationAsync();
        }


        /// <summary>
        /// Get all data
        /// </summary>
        /// <returns>List with all geo data</returns>
        public async Task<List<GeoPoint>> GetGeoPointsAsync()
        {
            string sql = "SELECT * FROM GeoData";

            using (var conn = new SqlConnection(Settings.DBConnectionString))
            {
                var res = await conn.QueryAsync<GeoPoint>(sql);
                return res.ToList();
            }
        }
    }
}