using LocationManager.API.Dtos;
using LocationManager.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocationManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchLocationsController : ControllerBase
    {
        private readonly ILocationManager _locationManager;

        public SearchLocationsController(ILocationManager locationManager)
        {
            _locationManager = locationManager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SearchLocationByQueryResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SearchLocation(string query, int limit)
        {
            var result = await _locationManager.SearchLocationByQueryAsync(query, limit);
            return !result.Any() ? NotFound() : Ok(result);
        }
    }
}
