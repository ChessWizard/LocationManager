using LocationManager.API.Dtos;
using LocationManager.API.Services.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace LocationManager.API.Services
{
    public class LocationManager : ILocationManager
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string _reverseUrl;
        private string _searchByQueryUrl;
        public LocationManager(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _reverseUrl = _configuration.GetSection("LocationUrls:ReverseUrl").Value;
            _searchByQueryUrl = _configuration.GetSection("LocationUrls:SearchByQueryWithLimit").Value;

            var productValue = new ProductInfoHeaderValue("ScraperBot", "1.0");
            var commentValue = new ProductInfoHeaderValue("(+http://www.example.com/ScraperBot.html)");

            _httpClient.DefaultRequestHeaders.UserAgent.Add(productValue);
            _httpClient.DefaultRequestHeaders.UserAgent.Add(commentValue);
        }
        public async Task<GetCurrentLocationQueryResult> GetCurrentLocationAsync(string latitude, string longtitude)
        {
            // dynamic url change
            var currentLocationUrl = _reverseUrl.Replace("$latitude", latitude).Replace("$longitude", longtitude);

            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(currentLocationUrl)
            };
            
            var currentLocationResult = await _httpClient.SendAsync(requestMessage);

            if (!currentLocationResult.IsSuccessStatusCode)
                return null;

            var currentLocationModel = await currentLocationResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<GetCurrentLocationQueryResult>(currentLocationModel);

            return result;
        }

       
        public async Task<List<SearchLocationByQueryResult>> SearchLocationByQueryAsync(string query, int limit)
        {
            var searchByQueryUrl = _searchByQueryUrl.Replace("query", query).Replace("take", limit.ToString());

            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(searchByQueryUrl)
            };

            var searchByQueryResult = await _httpClient.SendAsync(requestMessage);

            if (!searchByQueryResult.IsSuccessStatusCode)
                return null;

            var currentLocationModel = await searchByQueryResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<SearchLocationByQueryResult>>(currentLocationModel);

            return result;
        }
    }
}
