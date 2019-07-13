using System;
using System.ComponentModel.DataAnnotations;
using HT.Sports.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HT.Sports.UI.Web.External.ViewModels.Pages.Trips
{
    public class TripCreateViewModel
    {
        [Display(Name = "Trip Type")]
        [Required]
        public TripTypes TripType { get; set; }

        [Display(Name = "Trip Start Longitude (X)")]
        [Range(-180, 180)]
        [Required]
        public double TripStartLongitude { get; set; }

        [Range(-90, 90)]
        [Display(Name = "Trip Start Latitude (Y)")]
        [Required]
        public double TripStartLatitude { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOccurred { get; set; }
    }
}
