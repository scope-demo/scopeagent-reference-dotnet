using System;
using System.ComponentModel.DataAnnotations;

namespace Reference.CSharp
{
    /// <summary>
    /// Geo Entity
    /// </summary>
    public class GeoEntity
    {
        /// <summary>
        /// UUID
        /// </summary>
        [Key]
        public Guid Uuid { get; set; }
        /// <summary>
        /// Latitude
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// Longitude
        /// </summary>
        public double Longitude { get; set; }
        /// <summary>
        /// Place Id
        /// </summary>
        public long PlaceId { get; set; }
        /// <summary>
        /// Display name
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// City name
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// County
        /// </summary>
        public string County { get; set; }
        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Country code
        /// </summary>
        public string CountryCode { get; set; }
    }
}