using System.Threading.Tasks;
using HT.Sports.Entities;

namespace HT.Sports.Data.EF.Operations
{
    internal class AddAsyncOperation<TRepo, TEntity, TKey>
       where TEntity : EntityBase<TKey>
       where TRepo : RepoBase<TEntity, TKey>, IReadableById<int, TEntity>
    {
        private readonly TRepo _repo;

        public AddAsyncOperation(TRepo repo)
        {
            _repo = repo;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await _repo.Context.Set<TEntity>().AddAsync(entity);
            return result.Entity;
        }
    }
}
