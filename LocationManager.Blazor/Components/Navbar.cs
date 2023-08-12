using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

namespace LocationManager.Blazor.Components
{
    public partial class Navbar
    {
        [Inject]
        private NavigationManager _navigationManager { get; set; }

        [Parameter]
        [SupplyParameterFromQuery]
        public static string query { get; set; }

        private void NavigateToCurrentLocation()
        {
            _navigationManager.NavigateTo("/currentLocation");
        }

        private void NavigateToHome()
        {
            _navigationManager.NavigateTo("/index");
        }
    }
}
