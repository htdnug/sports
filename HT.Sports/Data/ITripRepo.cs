using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HT.Sports.Entities;

namespace HT.Sports.Data
{
    public interface ITripRepo
    {
        Task<int> AddAsync(Trip trip);
        Task<int> DeleteAsync(int id);
        Task<bool> DuplicateExistsAsync(Trip trip);
        Task<List<Trip>> GetAllAsync();
        Task<Trip> GetByIdAsync(int id);
        Task<int> UpdateAsync(Trip trip, Action<Trip, Trip> propertyCopyAction);
    }
}
