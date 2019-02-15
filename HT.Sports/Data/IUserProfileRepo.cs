using System.Collections.Generic;
using System.Threading.Tasks;
using HT.Sports.Entities;

namespace HT.Sports.Data
{
    public interface IUserProfileRepo
    {
        List<UserProfile> GetAll();
        Task<List<UserProfile>> GetAllAsync();
    }
}
