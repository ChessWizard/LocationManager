using Newtonsoft.Json;

namespace LocationManager.API.Dtos
{
    public class GetCurrentLocationQuery
    {
        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }

    
}
