using System;
using System.Threading.Tasks;
using HT.Sports.Entities;
using HT.Sports.Services.Contracts;
using HT.Sports.UI.Web.External.Models;
using HT.Sports.UI.Web.External.ViewModels.Pages.Trips;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HT.Sports.UI.Web.External.Pages.Trips
{
    public class CreateModel : PageModel
    {
        private readonly ITripService _tripService;

        public CreateModel(ITripService tripService)
        {
            this._tripService = tripService;           
        }

        public IActionResult OnGet()
        {
            return this.Page();
        }

        [BindProperty]
        public TripCreateViewModel Trip { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return this.Page();
            }

            var trip = new Trip()
            {
                TripType = Trip.TripType,
                TripStartLatitude = Trip.TripStartLatitude,
                TripStartLongitude = Trip.TripStartLongitude,
                DateOccurred = Trip.DateOccurred,

                //set to -1 if user is not logged in.
                //This will correspond to an "unregistered user" of sorts in the db until these features are made unavailable to unregistered users.
                UserProfileId = HttpContext.Session.GetInt32(SessionKeys.CurrentUserId) ?? -1
            };

            await this._tripService.CreateAsync(trip);

            return this.RedirectToPage("./Index");
        }
    }
}
