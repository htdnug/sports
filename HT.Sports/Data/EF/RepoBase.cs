using HT.Sports.Entities;
using Microsoft.EntityFrameworkCore;

namespace HT.Sports.Data.EF
{
    public abstract class RepoBase<T> where T : EntityBase
    {
        protected readonly SportsContext Db;
        
        public RepoBase(SportsContext db)
        {
            this.Db = db;
        }

        public SportsContext Context => this.Db;
        protected DbSet<T> Table => this.Db.Set<T>();
    }
}
