using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HT.Sports.Entities;
using System.ComponentModel.DataAnnotations;
using HT.Sports.Services.Contracts;

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
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOccurred { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return this.Page();
            }

            var trip = new Trip { DateOccurred = this.DateOccurred };
            await this._tripService.CreateAsync(trip);

            return this.RedirectToPage("./Index");
        }
    }
}
