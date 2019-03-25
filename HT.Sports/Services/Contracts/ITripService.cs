using System;
using System.Threading.Tasks;
using HT.Sports.Entities;

namespace HT.Sports.Services.Contracts
{
    public interface ITripService
    {
        Task<int> DeleteAsync(int id);
        Task<int> CreateAsync(Trip trip);
        Task<int> UpdateAsync(int id, Action<Trip, Trip> propertyCopyAction);
    }
}
