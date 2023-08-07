using LocationManager.API.Dtos;
using LocationManager.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.JavaScript;

namespace LocationManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentLocationsController : ControllerBase
    {
        private readonly ILocationManager _locationManager;
        public CurrentLocationsController(ILocationManager locationManager)
        {
            _locationManager = locationManager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCurrentLocationQueryResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCurrentLocation([FromQuery]GetCurrentLocationQuery request)
        {
            var result = await _locationManager.GetCurrentLocationAsync(request.Latitude, request.Longitude);
            return result is null ? NotFound() : Ok(result);
        }
    }
}
