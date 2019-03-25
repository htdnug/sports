using System.Threading.Tasks;
using HT.Sports.Entities;

namespace HT.Sports.Data.EF.Operations
{
    internal class DeleteAsyncOperation<TRepo, TEntity, TKey>
        where TEntity : EntityBase<TKey>
        where TRepo : RepoBase<TEntity>, IReadableById<TKey, TEntity>
        where TKey : struct
    {
        private readonly TRepo _repo;

        public DeleteAsyncOperation(TRepo repo)
        {
            _repo = repo;
        }

        public async Task<int> DeleteAsync(TKey id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null)
            {
                return 0;
            }

            _repo.Context.Set<TEntity>().Remove(entity);
            return 1;
        }
    }
}
