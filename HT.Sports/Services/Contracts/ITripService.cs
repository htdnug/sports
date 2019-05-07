using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HT.Sports.Entities;

namespace HT.Sports.Services.Contracts
{
    public interface ITripService
    {
        Task<int> DeleteAsync(int id);
        Task<int> CreateAsync(Trip trip);
        Task<int> UpdateAsync(Trip trip, Action<Trip, Trip> propertyCopyAction);
        Task<List<Trip>> GetAllAsync();
        Task<List<Trip>> GetAllAndRelatedUserProfileAsync();
        Task<Trip> GetByIdAsync(int id);
        Task<Trip> GetByIdAndUserProfileAsync(int id);
    }
}
