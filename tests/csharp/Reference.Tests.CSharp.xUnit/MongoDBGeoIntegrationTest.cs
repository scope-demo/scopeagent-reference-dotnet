using Microsoft.Extensions.Logging;
using OpenTracing.Noop;
using OpenTracing.Util;
using Reference.CSharp;
using System.Threading.Tasks;
using Xunit;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedVariable

namespace Reference.Tests.CSharp.xUnit
{
    /// <summary>
    /// MongoDB Geo Integration Test
    /// </summary>
    public class MongoDBGeoIntegrationTest
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Initialize test
        /// </summary>
        public MongoDBGeoIntegrationTest()
        {
            //If no global tracer is registered (not running with scope-run), we register the Noop tracer
            if (!GlobalTracer.IsRegistered())
                GlobalTracer.Register(NoopTracerFactory.Create());

            var loggerFactory = new LoggerFactory();
            _logger = loggerFactory.CreateLogger<MongoDBGeoIntegrationTest>();
        }

        /// <summary>
        /// Mongo Geo Test
        /// </summary>
        /// <returns>Test task</returns>
        [Fact]
        public async Task MongoOKTest()
        {
            const string UUID = "9E219725-490E-4509-A42D-D0388DF317D4";

            var tracer = GlobalTracer.Instance;

            GeoPoint geoPoint;
            var geoServiceCache = new GeoServiceRedisCache();
            var geoService = new GeoService();

            using (var scope = tracer.BuildSpan("Get GeoPoint Data").StartActive())
            {
                _logger.LogInformation("Getting data from cache.");
                geoPoint = await geoServiceCache.GetGeoPointAsync(UUID);
                if (geoPoint == null)
                {
                    _logger.LogWarning("The GeoPoint was not found in the cache.");
                    geoPoint = await geoService.GetGeoPointAsync(UUID);
                    Assert.NotNull(geoPoint);
                    _logger.LogInformation("The GeoPoint was retrieved from the GeoService: {geoPoint}", geoPoint);
                    await geoServiceCache.SetGeoPointAsync(UUID, geoPoint);
                }
                else
                    _logger.LogInformation("The GeoPoint was found in the cache: {geoPoint}", geoPoint);
            }

            OpenStreetMapItem streetMap;
            var openStreetMapServiceCache = new OpenStreetMapRedisCache();
            var openStreetMapService = new OpenStreetMapService();

            using (var scope = tracer.BuildSpan("Get OpenStreet Data").StartActive())
            {
                _logger.LogInformation("Getting data from cache.");
                streetMap = await openStreetMapServiceCache.GetOpenStreetMapAsync(UUID);
                if (streetMap == null)
                {
                    _logger.LogWarning("The OpenStreet data was not found in the cache.");
                    streetMap = await openStreetMapService.GetOpenStreetMapAsync(geoPoint);
                    Assert.NotNull(streetMap);
                    _logger.LogInformation("The OpenStreet data was retrieved from the Service: {openStreetMap}", streetMap);
                    await openStreetMapServiceCache.SetOpenStreetMapAsync(UUID, streetMap);
                }
                else
                    _logger.LogInformation("The OpenStreet data was found in the cache: {openStreetMap}", streetMap);
            }

            IPersistentData dbServices = new MongoDBService();

            using (var scope = tracer.BuildSpan("Save data").StartActive())
            {
                _logger.LogInformation("Ensuring migrations");
                await dbServices.EnsureMigrationAsync();

                _logger.LogInformation("Saving data to DB");
                if (await dbServices.SaveDataAsync(geoPoint, streetMap))
                    _logger.LogInformation("Data saved to db.");
                else
                    _logger.LogInformation("Data is already in the db.");
            }

            using (var scope = tracer.BuildSpan("Cleaning").StartActive())
            {
                _logger.LogInformation("Cleaning GeoService cache data.");
                await geoServiceCache.DeleteAsync(UUID);
                await openStreetMapServiceCache.DeleteAsync(UUID);
            }
        }
    }
}
