using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
// ReSharper disable UnusedMember.Global

namespace Reference.CSharp
{
    /// <summary>
    /// MongoDB service
    /// </summary>
    public class MongoDBService : IPersistentData
    {
        private readonly IMongoDatabase _database;

        static MongoDBService()
        {
            BsonClassMap.RegisterClassMap<GeoEntity>(map =>
            {
                map.MapIdProperty(x => x.Uuid);
                map.MapProperty(x => x.Latitude);
                map.MapProperty(x => x.Longitude);
                map.MapProperty(x => x.PlaceId);
                map.MapProperty(x => x.DisplayName);
                map.MapProperty(x => x.City);
                map.MapProperty(x => x.County);
                map.MapProperty(x => x.State);
                map.MapProperty(x => x.Country);
                map.MapProperty(x => x.CountryCode);
            });
        }

        public MongoDBService()
        {
            var client = new MongoClient(Settings.MongoDBUrl);
            _database = client.GetDatabase(Settings.MongoDBDatabase);
        }

        /// <inheritdoc />
        public async Task EnsureMigrationAsync()
        {
            var lstCollection = await (await _database.ListCollectionNamesAsync()).ToListAsync();
            if (!lstCollection.Any(col => col == Settings.MongoDBCollection))
                await _database.CreateCollectionAsync(Settings.MongoDBCollection);
        }

        /// <inheritdoc />
        public async Task<bool> SaveDataAsync(GeoPoint geoPoint, OpenStreetMapItem item)
        {
            var geoCollection = _database.GetCollection<GeoEntity>(Settings.MongoDBCollection);

            var entity = await (await geoCollection.FindAsync(i => i.Uuid == geoPoint.Uuid)).FirstOrDefaultAsync();
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

            await geoCollection.InsertOneAsync(entity);
            return true;

        }

        /// <inheritdoc />
        public async Task<List<(GeoPoint GeoPoint, OpenStreetMapItem StreetMap)>> GetAllAsync()
        {
            var geoCollection = _database.GetCollection<GeoEntity>(Settings.MongoDBCollection);

            var lstResponse = new List<(GeoPoint GeoPoint, OpenStreetMapItem StreetMap)>();
            var data = await (await geoCollection.FindAsync(i => true)).ToListAsync();
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
            return lstResponse;
        }

    }
}