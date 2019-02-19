using System.Collections.Generic;

namespace HT.Sports.Entities
{
    public class UserProfile : EntityBase
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }

        public ICollection<Trip> Trips { get; } = new List<Trip>();
    }
}
