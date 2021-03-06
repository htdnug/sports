﻿using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using HT.Sports.Entities;

namespace HT.Sports.Data.EF.Operations
{
    internal class UpdateAsyncOperation<TRepo, TEntity, TKey>
    where TEntity : EntityBase<TKey>
    where TRepo : RepoBase<TEntity, TKey>, IReadableById<TKey, TEntity>
    {
        private readonly TRepo _repo;

        public UpdateAsyncOperation(TRepo repo)
        {
            _repo = repo;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, Action<TEntity, TEntity> propertyCopyAction)
        {
            if (entity.Id.Equals(default(TKey)))
            {
                return null; 
            }

            var dbEntity = await _repo.GetByIdAsync(entity.Id);
            if (dbEntity == null)
            {
                return null;
            }

            propertyCopyAction(dbEntity, entity);
            return _repo.Context.Set<TEntity>().Update(dbEntity).Entity;

        }
    }
}
