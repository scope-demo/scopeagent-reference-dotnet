using System.Collections.Generic;
using System.Threading.Tasks;
// ReSharper disable UnusedMember.Global

namespace Reference.CSharp
{
    /// <summary>
    /// Persistent data interface
    /// </summary>
    public interface IPersistentData
    {
        /// <summary>
        /// Ensure migration
        /// </summary>
        /// <returns>Migration task</returns>
        Task EnsureMigrationAsync();
        /// <summary>
        /// Save data to database
        /// </summary>
        /// <param name="geoPoint">GeoPoint value</param>
        /// <param name="item">OpenStreetMapItem value</param>
        /// <returns>Save database task</returns>
        Task<bool> SaveDataAsync(GeoPoint geoPoint, OpenStreetMapItem item);
        /// <summary>
        /// Get all data
        /// </summary>
        /// <returns>List with all geo data</returns>
        Task<List<(GeoPoint GeoPoint, OpenStreetMapItem StreetMap)>> GetAllAsync();
    }
}