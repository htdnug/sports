using System.Threading.Tasks;
using HT.Sports.Entities;

namespace HT.Sports.Data.EF.Operations
{
    internal class DeleteAsyncOperation<TRepo, TEntity, TKey>
        where TEntity : EntityBase<TKey>
        where TRepo : RepoBase<TEntity, TKey>, IReadableById<TKey, TEntity>
    {
        private readonly TRepo _repo;

        public DeleteAsyncOperation(TRepo repo)
        {
            _repo = repo;
        }

        public async Task<int> DeleteAsync(TKey id)
        {
            var dbEntity = await _repo.GetByIdAsync(id);
            if (dbEntity == null)
            {
                return 0;
            }

            _repo.Context.Set<TEntity>().Remove(dbEntity);
            return 1;
        }
    }
}
