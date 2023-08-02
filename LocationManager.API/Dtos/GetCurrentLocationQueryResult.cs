using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace LocationManager.API.Dtos
{
    public class GetCurrentLocationQueryResult
    {
        public int place_id { get; set; }
        public string licence { get; set; }
        public string osm_type { get; set; }
        public int osm_id { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string @class { get; set; }
        public string type { get; set; }
        public int place_rank { get; set; }
        public double importance { get; set; }
        public string addresstype { get; set; }
        public string name { get; set; }
        public string display_name { get; set; }
        public List<string> boundingbox { get; set; }

        // Serialize ve Deserailize ederken api'den gelen address ismi ile karşılansın
        // bunu yaparak kendimiz Address şeklinde alias eklemiş oluruz
        [JsonPropertyName("address")]
        public Address Address { get; set; }
    }

    public class Address
    {
        public string road { get; set; }
        public string suburb { get; set; }
        public string town { get; set; }
        public string municipality { get; set; }
        public string district { get; set; }

        [JsonPropertyName("ISO3166-2-lvl4")]
        public string ISO31662lvl4 { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
    }
}
