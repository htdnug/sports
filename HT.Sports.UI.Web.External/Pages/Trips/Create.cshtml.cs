using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HT.Sports.Entities;
using System.ComponentModel.DataAnnotations;
using HT.Sports.Data;

namespace HT.Sports.UI.Web.External.Pages.Trips
{
    public class CreateModel : PageModel
    {
        private readonly ITripRepo _tripRepo;

        public CreateModel(ITripRepo tripRepo)
        {
            this._tripRepo = tripRepo;
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
            await this._tripRepo.AddAsync(trip);

            return this.RedirectToPage("./Index");
        }
    }
}
