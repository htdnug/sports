using System.Threading.Tasks;

namespace HT.Sports.Data
{
    public interface IDeleteable<TKey>
    {
        Task<int> DeleteAsync(TKey id);
    }
}
