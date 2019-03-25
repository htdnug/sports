using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HT.Sports.Entities;
using Microsoft.EntityFrameworkCore;

namespace HT.Sports.Data.EF
{
    public class UserProfileRepo : RepoBase<UserProfile, int>, IUserProfileRepo
    {
        public UserProfileRepo(SportsContext db) 
            : base(db)
        {
        }

        public List<UserProfile> GetAll()
        {
            return this.BuildOrderedQuery().ToList();
        }

        public async Task<List<UserProfile>> GetAllAsync()
        {
            return await this.BuildOrderedQuery().ToListAsync();
        }

        private IQueryable<UserProfile> BuildOrderedQuery()
        {
            return this.Table.AsNoTracking().OrderBy(x => x.DisplayName);
        }
    }
}
