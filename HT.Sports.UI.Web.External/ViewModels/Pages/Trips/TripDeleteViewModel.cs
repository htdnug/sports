using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HT.Sports.Entities;

namespace HT.Sports.UI.Web.External.ViewModels.Pages.Trips
{
    public class TripDeleteViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Trip Type")]
        public TripTypes TripType { get; set; }

        [Display(Name = "Trip Start Longitude (X)")]
        [Range(-180, 180)]
        public double TripStartLongitude { get; set; }

        [Range(-90, 90)]
        [Display(Name = "Trip Start Latitude (Y)")]
        public double TripStartLatitude { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime DateOccurred { get; set; }

        [Display(Name = "Created by user")]
        public string UserName { get; set; }
    }
}
