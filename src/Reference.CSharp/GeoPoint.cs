using System;
using Newtonsoft.Json;

namespace Reference.CSharp
{
    /// <summary>
    /// Geo point
    /// </summary>
    public class GeoPoint
    {
        /// <summary>
        /// UUID
        /// </summary>
        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }
        /// <summary>
        /// Latitude
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        /// <summary>
        /// Longitude
        /// </summary>
        [JsonProperty("lon")]
        public double Longitude { get; set; }
    }
}