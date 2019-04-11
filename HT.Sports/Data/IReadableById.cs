using System.Threading.Tasks;
using HT.Sports.Entities;

namespace HT.Sports.Data
{
    public interface IReadableById<TKey, TEntity>
    {
        Task<TEntity> GetByIdAsync(TKey id);
    }
}
