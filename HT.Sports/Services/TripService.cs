﻿using System;
using System.Threading.Tasks;
using HT.Sports.Data;
using HT.Sports.Data.EF;
using HT.Sports.Entities;
using HT.Sports.Services.Contracts;

namespace HT.Sports.Services
{
    public class TripService : ITripService
    {
        private readonly SportsContext _context;
        private readonly ITripRepo _tripRepo;

        public TripService(SportsContext context, ITripRepo tripRepo)
        {
            this._context = context;
            this._tripRepo = tripRepo;
        }

        public async Task<int> DeleteAsync(int id)
        {
            await this._tripRepo.DeleteAsync(id);
            return await this._context.SaveChangesAsync();
        }

        public async Task<int> CreateAsync(Trip trip)
        {
            await this._tripRepo.AddAsync(trip);
            return await this._context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Trip trip, Action<Trip, Trip> propertyCopyAction)
        {
            await this._tripRepo.UpdateAsync(trip, propertyCopyAction);
            return await this._context.SaveChangesAsync();
        }
    }
}
