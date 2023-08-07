using LocationManager.API.Dtos;

namespace LocationManager.API.Services.Interfaces
{
    public interface ILocationManager
    {
        Task<GetCurrentLocationQueryResult> GetCurrentLocationAsync(string latitude, string longtitude);

        Task<List<SearchLocationByQueryResult>> SearchLocationByQueryAsync(string query, int limit);
    }
}
