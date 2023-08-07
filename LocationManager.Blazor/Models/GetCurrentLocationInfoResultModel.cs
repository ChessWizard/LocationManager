using System.Text.Json.Serialization;

namespace LocationManager.Blazor.Models
{
    public class GetCurrentLocationInfoResultModel
    {
        [JsonPropertyName("place_id")]
        public int PlaceId { get; set; }

        [JsonPropertyName("licence")]
        public string Licence { get; set; }

        [JsonPropertyName("osm_type")]
        public string OsmType { get; set; }

        [JsonPropertyName("osm_id")]
        public int OsmId { get; set; }

        [JsonPropertyName("lat")]
        public string Lat { get; set; }

        [JsonPropertyName("lon")]
        public string Lon { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("boundingbox")]
        public List<string> Boundingbox { get; set; }
    }

    public class Address
    {
        [JsonPropertyName("suburb")]
        public string Suburb { get; set; }

        [JsonPropertyName("town")]
        public string Town { get; set; }

        [JsonPropertyName("municipality")]
        public string Municipality { get; set; }

        [JsonPropertyName("district")]
        public string District { get; set; }

        [JsonPropertyName("ISO3166-2-lvl4")]
        public string ISO31662Lvl4 { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }
    }
}

