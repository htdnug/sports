using System.Collections.Generic;

namespace HT.Sports.Entities
{
    public class UserProfile : EntityBase<int>
    {
        public string DisplayName { get; set; }
        public ICollection<Trip> Trips { get; } = new List<Trip>();
    }
}
