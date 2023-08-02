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
        public LocationManager(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _reverseUrl = _configuration.GetSection("LocationUrls:ReverseUrl").Value;
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
                Content = new StringContent(JsonSerializer.Serialize(new JObject()), Encoding.UTF8, "application/json"),
                RequestUri = new Uri(currentLocationUrl)
            };
            
            var currentLocationResult = await _httpClient.SendAsync(requestMessage);

            if (!currentLocationResult.IsSuccessStatusCode)
                return null;

            var currentLocationModel = await currentLocationResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<GetCurrentLocationQueryResult>(currentLocationModel);

            return result;
        }
    }
}
