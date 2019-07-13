using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using HT.Sports.Entities;
using Microsoft.EntityFrameworkCore;

namespace HT.Sports.Data.EF.Operations
{
    internal class GetByIdAsyncOperation<TRepo, TEntity, TKey>
    where TEntity : EntityBase<TKey>
    where TRepo : RepoBase<TEntity,TKey>
    {
        private readonly TRepo _repo;

        public GetByIdAsyncOperation(TRepo repo)
        {
            _repo = repo;
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            var result = await _repo.Context.Set<TEntity>().FindAsync(id);
            return result;
        }
    }
}
