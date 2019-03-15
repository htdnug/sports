using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HT.Sports.Data.EF.Operations;
using HT.Sports.Entities;
using Microsoft.EntityFrameworkCore;

namespace HT.Sports.Data.EF
{
    public class TripRepo : RepoBase<Trip>, ITripRepo
    {
        public TripRepo(SportsContext db) 
            : base(db)
        {
        }

        public async Task<int> AddAsync(Trip trip)
        {
            this.Table.Add(trip);
            return await this.Db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var operation = new DeleteAsyncOperation<TripRepo, Trip>(this);
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

        public async Task<int> UpdateAsync(Trip trip, Action<Trip, Trip> propertyCopyAction)
        {
            if (trip.Id == 0)
            {
                return 0;
            }

            var dbTrip = await this.GetByIdAsync(trip.Id);
            if (dbTrip == null)
            {
                return 0;
            }

            propertyCopyAction(dbTrip, trip);
            return await this.Db.SaveChangesAsync();
        }
    }
}
