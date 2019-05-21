using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
// ReSharper disable UnusedMember.Global

namespace Reference.CSharp
{
    /// <summary>
    /// Database service
    /// </summary>
    public class DatabaseService
    {
        /// <summary>
        /// Ensure migration
        /// </summary>
        /// <returns>Migration task</returns>
        public async Task EnsureMigrationAsync()
        {
            using (var context = new GeoContext())
                await context.Database.MigrateAsync();
        }

        /// <summary>
        /// Save data to database
        /// </summary>
        /// <param name="geoPoint">GeoPoint value</param>
        /// <param name="item">OpenStreetMapItem value</param>
        /// <returns>Save database task</returns>
        public async Task<bool> SaveDataAsync(GeoPoint geoPoint, OpenStreetMapItem item)
        {
            using (var context = new GeoContext())
            {
                var entity = await context.GeoData.FindAsync(geoPoint.Uuid);
                if (entity != null)
                    return false;

                entity = new GeoEntity
                {
                    Uuid = geoPoint.Uuid,
                    Latitude = geoPoint.Latitude,
                    Longitude = geoPoint.Longitude,
                    PlaceId = item.PlaceId,
                    DisplayName = item.DisplayName,
                    City = item.Address?.City,
                    Country = item.Address?.Country,
                    CountryCode = item.Address?.CountryCode,
                    County = item.Address?.County,
                    State = item.Address?.State
                };

                await context.GeoData.AddAsync(entity);
                return await context.SaveChangesAsync() > 0;
            }
        }

        /// <summary>
        /// Get all data
        /// </summary>
        /// <returns>List with all geo data</returns>
        public async Task<List<(GeoPoint GeoPoint, OpenStreetMapItem StreetMap)>> GetAllAsync()
        {
            var lstResponse = new List<(GeoPoint GeoPoint, OpenStreetMapItem StreetMap)>();
            using (var context = new GeoContext())
            {
                var data = await context.GeoData.ToArrayAsync();
                foreach (var item in data)
                {
                    lstResponse.Add((
                        new GeoPoint
                        {
                            Uuid = item.Uuid,
                            Latitude = item.Latitude,
                            Longitude = item.Longitude
                        }, 
                        new OpenStreetMapItem
                        {
                            PlaceId = item.PlaceId,
                            DisplayName = item.DisplayName,
                            Address = new OpenStreetMapAddress
                            {
                                City = item.City,
                                Country = item.Country,
                                CountryCode = item.CountryCode,
                                County = item.County,
                                State = item.State
                            }
                        }));
                }
            }
            return lstResponse;
        }
    }
}