using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using HT.Sports.Data;
using HT.Sports.Services.Contracts;
using HT.Sports.UI.Web.External.ViewModels.Pages.Trips;

namespace HT.Sports.UI.Web.External.Pages.Trips
{
    public class DeleteModel : PageModel
    {
        private readonly ITripService _tripService;

        public DeleteModel(ITripRepo tripRepo, ITripService tripService)
        {
            this._tripService = tripService;
        }

       [BindProperty]
       public TripDeleteViewModel Trip { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (!id.HasValue)
            {
                return this.NotFound();
            }

            var trip = await this._tripService.GetByIdAndUserProfileAsync(id.Value);
            if (trip == null)
            {
                return this.NotFound();
            }

            Trip = new TripDeleteViewModel()
            {
                Id = trip.Id,
                TripType = trip.TripType,
                TripStartLatitude = trip.TripStartLatitude,
                TripStartLongitude = trip.TripStartLongitude,
                DateOccurred = trip.DateOccurred,
                UserName = trip.UserProfile.DisplayName
            };

            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            await this._tripService.DeleteAsync(id.Value);
            return RedirectToPage("./Index");
        }
    }
}
