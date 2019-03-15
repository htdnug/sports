using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HT.Sports.Data.EF;
using HT.Sports.Entities;

namespace HT.Sports.Data
{
    public interface ITripRepo : 
        IDeleteable<int>, 
        IAddable<Trip>,
        IReadableById<int, Trip>
    {
        Task<bool> DuplicateExistsAsync(Trip trip);
        Task<List<Trip>> GetAllAsync();
        Task<int> UpdateAsync(Trip trip, Action<Trip, Trip> propertyCopyAction);
    }
}
