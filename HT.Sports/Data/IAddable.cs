using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HT.Sports.Data
{
    public interface IAddable<TEntity>
    {
        Task<TEntity> AddAsync(TEntity entity);
    }
}
