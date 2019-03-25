using System.Threading.Tasks;

namespace HT.Sports.Data
{
    public interface IDeletable<TKey>
    {
        Task<TKey> DeleteAsync(TKey id);
    }
}
