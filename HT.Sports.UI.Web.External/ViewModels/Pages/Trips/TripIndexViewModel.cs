using System;
using System.ComponentModel.DataAnnotations;
using HT.Sports.Entities;

namespace HT.Sports.UI.Web.External.ViewModels.Pages.Trips
{
    public class TripIndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Trip Type")]
        public TripTypes TripType { get; set; }

        [Display(Name = "Trip Start Longitude")]
        public double TripStartLongitude { get; set; }

        [Display(Name = "Trip Start Latitude")]
        public double TripStartLatitude { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateOccurred { get; set; }

        [Display(Name = "Created by user")]
        public string UserName { get; set; }
    }
}
