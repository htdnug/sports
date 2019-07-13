using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HT.Sports.Services.Contracts;
using HT.Sports.UI.Web.External.ViewModels.Pages.Trips;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HT.Sports.UI.Web.External.Pages.Trips
{
    public class IndexModel : PageModel
    {
        private readonly ITripService _tripService;

        public IndexModel(ITripService tripService)
        {
            this._tripService = tripService;
        }

        public IEnumerable<TripIndexViewModel> Trips { get; set; }
        public TripIndexViewModel TripDisplayNames { get; set; } //always null.. just for giving display names to view.

        public async Task OnGetAsync()
        {
            var trips = await _tripService.GetAllAndRelatedUserProfileAsync();
            
            this.Trips = trips.Select(x => new TripIndexViewModel
            {
                Id = x.Id,              
                UserName = x.UserProfile.DisplayName,
                DateOccurred = x.DateOccurred,
                TripType = x.TripType,
                TripStartLatitude = x.TripStartLatitude,
                TripStartLongitude = x.TripStartLongitude,           
            });
        }
    }
}
