using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HT.Sports.Data.EF.Operations;
using HT.Sports.Entities;
using Microsoft.EntityFrameworkCore;

namespace HT.Sports.Data.EF
{
    public class TripRepo : RepoBase<Trip, int>, ITripRepo
    { 
        public TripRepo(SportsContext db)
            : base(db)
        {
        }

        public async Task<Trip> AddAsync(Trip trip)
        {
            var operation = new AddAsyncOperation<TripRepo, Trip, int>(this);
            return await operation.AddAsync(trip);
        }

        public async Task<Trip> UpdateAsync(Trip trip, Action<Trip, Trip> propertyCopyAction)
        {
            var operation = new UpdateAsyncOperation<TripRepo, Trip, int>(this);
            return await operation.UpdateAsync(trip, propertyCopyAction);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var operation = new DeleteAsyncOperation<TripRepo, Trip, int>(this);
            return await operation.DeleteAsync(id);
        }

        public async Task<bool> DuplicateExistsAsync(Trip trip)
        {
            return await this.Table.AnyAsync(x => x.Id == trip.Id);
        }

        public async Task<List<Trip>> GetAllAsync()
        {
            return await this.Table.AsNoTracking().OrderByDescending(x => x.DateOccurred).ToListAsync();
        }

        public async Task<Trip> GetByIdAsync(int id)
        {
            return await this.Table.FindAsync(id);
        }

        public async Task<int> TestMethod()
        {
            return await this.Db.SaveChangesAsync();
        }
    }
}
