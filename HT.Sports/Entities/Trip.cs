using System;

namespace HT.Sports.Entities
{
    public class Trip : EntityBase
    {
        public int Id { get; set; }
        public DateTime DateOccurred { get; set; }

        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
