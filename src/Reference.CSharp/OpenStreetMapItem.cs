using Newtonsoft.Json;

namespace Reference.CSharp
{
    /// <summary>
    /// OpenStreet Map
    /// </summary>
    public class OpenStreetMapItem
    {
        /// <summary>
        /// Place Id
        /// </summary>
        [JsonProperty("place_id")]
        public long PlaceId { get; set; }
        /// <summary>
        /// Display name
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        /// <summary>
        /// Address
        /// </summary>
        [JsonProperty("address")]
        public OpenStreetMapAddress Address { get; set; }
    }
}