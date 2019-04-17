using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HT.Sports.Entities;
using System.ComponentModel.DataAnnotations;
using HT.Sports.Data;
using HT.Sports.Services.Contracts;

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
        public int Id { get; set; }

        [BindProperty]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOccurred { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (!id.HasValue)
            {
                return this.NotFound();
            }

            var trip = await this._tripRepo.GetByIdAsync(id.Value);
            if (trip == null)
            {
                return this.NotFound();
            }

            this.Id = trip.Id;
            this.DateOccurred = trip.DateOccurred;
            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return this.Page();
            }

            var trip = new Trip
            {
                Id = this.Id,
                DateOccurred = this.DateOccurred
            };

            try
            {
                await this._tripService.UpdateAsync(trip, (dbVersion, formVersion) => {
                    dbVersion.DateOccurred = formVersion.DateOccurred;
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                var duplicateExists = await this._tripRepo.DuplicateExistsAsync(trip);
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
