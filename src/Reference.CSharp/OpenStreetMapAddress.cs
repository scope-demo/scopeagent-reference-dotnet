using Newtonsoft.Json;

namespace Reference.CSharp
{
    /// <summary>
    /// OpenStreet map address
    /// </summary>
    public class OpenStreetMapAddress
    {
        /// <summary>
        /// City name
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }
        /// <summary>
        /// County
        /// </summary>
        [JsonProperty("county")]
        public string County { get; set; }
        /// <summary>
        /// State
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }
        /// <summary>
        /// Country
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }
        /// <summary>
        /// Country code
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
    }
}