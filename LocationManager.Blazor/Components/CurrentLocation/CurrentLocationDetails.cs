using LocationManager.Blazor.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace LocationManager.Blazor.Components.CurrentLocation
{
    public partial class CurrentLocationDetails
    {
        [Inject]
        private IJSRuntime _jSRuntime { get; set; }
        [Inject]
        private HttpClient _httpClient { get; set; }
        private GetCurrentLocationResultModel currentLocationModel;
        private GetCurrentLocationInfoResultModel currentLocationInfoModel;

        private async Task<List<string>> GetCurrentLocationCoordinatesAsync()
        {
            var result = await _jSRuntime.InvokeAsync<GetCurrentLocationResultModel>("getLocation");

            List<string> coordinates = new()
            {
                result.Latitude.ToString().Replace(",", "."),
                result.Longitude.ToString().Replace(",", ".")             
            };

            return coordinates;
        }

        private async Task GetCurrentLocationDetailsAsync()
        {
            var parameters = await GetCurrentLocationCoordinatesAsync();

            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_httpClient.BaseAddress}CurrentLocations?Latitude={parameters[0]}&Longitude={parameters[1]}")
            };

            var result = await _httpClient.SendAsync(requestMessage);

            if (!result.IsSuccessStatusCode)
                return;

            var resultModel = await result.Content.ReadAsStringAsync();

            if (resultModel is null)
                return;

            currentLocationInfoModel = JsonSerializer.Deserialize<GetCurrentLocationInfoResultModel>(resultModel);
        }
    }
}
