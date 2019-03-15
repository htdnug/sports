using System.Threading.Tasks;

namespace HT.Sports.Services.Contracts
{
    public interface ITripService
    {
        Task<int> DeleteAsync(int id);
    }
}
