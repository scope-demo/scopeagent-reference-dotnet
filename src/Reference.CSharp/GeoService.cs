using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Reference.CSharp
{
    /// <summary>
    /// Geo service
    /// </summary>
    public class GeoService
    {
        private const string ServiceUrl = "http://flask-example-project.codescope.com:8000/car";

        /// <summary>
        /// Get GeoPoint
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>GeoPoint instance</returns>
        public async Task<GeoPoint> GetGeoPointAsync(string id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{ServiceUrl}/{id}");
                if (!response.IsSuccessStatusCode) 
                    throw new Exception("Error getting the GeoPoint");
                var jsonData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<GeoPoint>(jsonData);
            }
        } 
    }
}