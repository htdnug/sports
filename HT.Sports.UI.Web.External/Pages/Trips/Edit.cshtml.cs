using System.Threading.Tasks;
using HT.Sports.Data;
using HT.Sports.Entities;
using HT.Sports.Services.Contracts;
using HT.Sports.UI.Web.External.ViewModels.Pages.Trips;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HT.Sports.UI.Web.External.Pages.Trips
{
    public class EditModel : PageModel
    {
        private readonly ITripRepo _tripRepo;
        private readonly ITripService _tripService;

        public EditModel(ITripRepo tripRepo, ITripService tripService)
        {
            this._tripRepo = tripRepo;
            this._tripService = tripService;
        }

        [BindProperty]
        public TripEditViewModel Trip { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (!id.HasValue)
            {
                return this.NotFound();
            }

            var trip = await this._tripService.GetByIdAsync(id.Value);
            if (trip == null)
            {
                return this.NotFound();
            }

            Trip = new TripEditViewModel()
            {
                Id = trip.Id,
                TripStartLatitude = trip.TripStartLatitude,
                TripStartLongitude = trip.TripStartLongitude,
                TripType = trip.TripType,
                DateOccurred = trip.DateOccurred
            };
            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return this.Page();
            }

            var dbTrip = await this._tripService.GetByIdAsync(Trip.Id);

            var formTrip = new Trip
            {
                TripType = Trip.TripType,
                TripStartLatitude = Trip.TripStartLatitude,
                TripStartLongitude = Trip.TripStartLongitude,
                DateOccurred = Trip.DateOccurred
            };

            try
            {
                await this._tripService.UpdateAsync(dbTrip, (dbVersion, formVersion) =>
                {                  
                    dbTrip.TripType = formTrip.TripType;
                    dbTrip.TripStartLatitude = formTrip.TripStartLatitude;
                    dbTrip.TripStartLongitude = formTrip.TripStartLongitude;
                    dbTrip.DateOccurred = formTrip.DateOccurred;
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                var duplicateExists = await this._tripRepo.DuplicateExistsAsync(formTrip);
                if (!duplicateExists)
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
