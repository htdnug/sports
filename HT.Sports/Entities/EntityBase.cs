using System;
using HT.Sports.Data;
using System.Collections.Generic;

namespace HT.Sports.Entities
{
    public abstract class EntityBase<TKey> : IIdentifiable<TKey>
    {
        public TKey Id { get; set; }
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset DateModified { get; set; } = DateTimeOffset.Now;
        public string ModifiedBy { get; set; }
    }
}
