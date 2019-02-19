using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HT.Sports.Data;
using HT.Sports.UI.Web.External.ViewModels.Pages.Trips;

namespace HT.Sports.UI.Web.External.Pages.Trips
{
    public class IndexModel : PageModel
    {
        private readonly ITripRepo _tripRepo;

        public IndexModel(ITripRepo tripRepo)
        {
            this._tripRepo = tripRepo;
        }

        public IEnumerable<TripIndexViewModel> Trips { get;set; }

        public async Task OnGetAsync()
        {
            var trips = await _tripRepo.GetAllAsync();
            this.Trips = trips.Select(x => new TripIndexViewModel { Id = x.Id, DateOccurred = x.DateOccurred });
        }
    }
}
