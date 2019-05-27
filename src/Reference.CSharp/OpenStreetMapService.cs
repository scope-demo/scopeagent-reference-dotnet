using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Reference.CSharp
{
    /// <summary>
    /// OpenStreet map service
    /// </summary>
    public class OpenStreetMapService
    {
        private const string ServiceUrl = "https://nominatim.openstreetmap.org/reverse?format=json&lat={0}&lon={1}&zoom=18&addressdetails=1";

        /// <summary>
        /// Get OpenStreet Map data
        /// </summary>
        /// <param name="geoPoint">GeoPoint instance</param>
        /// <returns>OpenStreetMapItem instance</returns>
        public async Task<OpenStreetMapItem> GetOpenStreetMapAsync(GeoPoint geoPoint)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.TryParseAdd("Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.158 Safari/537.36 Vivaldi/2.5.1525.43");
                client.DefaultRequestHeaders.TryAddWithoutValidation(":authority", "nominatim.openstreetmap.org");
                client.DefaultRequestHeaders.TryAddWithoutValidation(":method", "GET");

                var response = await client.GetAsync(string.Format(ServiceUrl, geoPoint.Latitude, geoPoint.Longitude).Replace(",", "."));
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Error getting the OpenStreetMap");
                var jsonData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<OpenStreetMapItem>(jsonData);
            }
        }
    }
}
