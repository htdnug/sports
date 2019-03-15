using HT.Sports.Entities;
using Microsoft.EntityFrameworkCore;

namespace HT.Sports.Data.EF
{
    public abstract class RepoBase<TEntity> where TEntity : EntityBase
    {
        protected readonly DbContext Db;
        
        public RepoBase(DbContext db)
        {
            this.Db = db;
        }

        public SportsContext Context => this.Db as SportsContext;
        protected DbSet<TEntity> Table => this.Db.Set<TEntity>();
    }
}
