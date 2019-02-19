using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using HT.Sports.Data;

namespace HT.Sports.UI.Web.External.Pages.Trips
{
    public class DeleteModel : PageModel
    {
        private readonly ITripRepo _tripRepo;

        public DeleteModel(ITripRepo tripRepo)
        {
            this._tripRepo = tripRepo;
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            await this._tripRepo.DeleteAsync(id.Value);
            return RedirectToPage("./Index");
        }
    }
}
