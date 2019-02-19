using System;

namespace HT.Sports.Entities
{
    public abstract class EntityBase
    {
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset DateModified { get; set; } = DateTimeOffset.Now;
        public string ModifiedBy { get; set; }
    }
}
