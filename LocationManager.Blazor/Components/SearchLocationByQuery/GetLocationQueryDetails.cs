using LocationManager.Blazor.Models;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace LocationManager.Blazor.Components.SearchLocationByQuery
{
    public partial class GetLocationQueryDetails
    {
        [Inject]
        private HttpClient _httpClient { get; set; }

        [Parameter]
        public string Query { get; set; }

        [Parameter]
        public string Limit { get; set; }

        private async Task<List<SearchLocationByQueryResult>> GetLocationQueryDetailsAsync()
        {
            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_httpClient.BaseAddress}SearchLocations?query={Query}&limit={Limit}")
            };

            var result = await _httpClient.SendAsync(requestMessage);

            if (!result.IsSuccessStatusCode)
                return (List<SearchLocationByQueryResult>)Enumerable.Empty<SearchLocationByQueryResult>();

            var resultModel = await result.Content.ReadAsStringAsync();
            var model = JsonSerializer.Deserialize<List<SearchLocationByQueryResult>>(resultModel);

            return model;
        }
    }
}
