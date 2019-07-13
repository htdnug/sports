using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HT.Sports.Data.EF;
using HT.Sports.Entities;


namespace HT.Sports.Data
{
    public interface ITripRepo : 
        IDeletable<int>, 
        IUpdateable<Trip>,
        IAddable<Trip>,
        IReadableById<int, Trip>
    {
        Task<bool> DuplicateExistsAsync(Trip trip);
        Task<List<Trip>> GetAllAsync();
        Task<List<Trip>> GetAllAndRelatedUserProfileAsync();
        Task<Trip> GetByIdAndUserProfileAsync(int id);
    }
}
