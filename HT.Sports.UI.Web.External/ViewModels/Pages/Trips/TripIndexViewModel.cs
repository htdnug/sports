using System;
using System.ComponentModel.DataAnnotations;

namespace HT.Sports.UI.Web.External.ViewModels.Pages.Trips
{
    public class TripIndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateOccurred { get; set; }
    }
}
