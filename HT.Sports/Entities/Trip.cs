using System;
using System.ComponentModel.DataAnnotations;

namespace HT.Sports.Entities
{

    public enum TripTypes {None = 0, Fishing = 1, Hunting = 2}

    public class Trip : EntityBase<int>

    {
        public TripTypes TripType { get; set; }
        public double TripStartLongitude { get; set; }
        public double TripStartLatitude { get; set; }
        public int UserProfileId { get; set; }
        public DateTime DateOccurred { get; set; }       
        public UserProfile UserProfile { get; set; }
    }
}
