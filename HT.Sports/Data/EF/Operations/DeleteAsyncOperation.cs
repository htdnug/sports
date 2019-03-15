using System.Threading.Tasks;
using HT.Sports.Entities;

namespace HT.Sports.Data.EF.Operations
{
    internal class DeleteAsyncOperation<TRepo, TEntity>
        where TEntity : EntityBase
        where TRepo : RepoBase<TEntity>, IReadableById<int, TEntity>
    {
        private readonly TRepo _repo;

        public DeleteAsyncOperation(TRepo repo)
        {
            _repo = repo;
        }

        public async Task<int> DeleteAsync(int id)
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
