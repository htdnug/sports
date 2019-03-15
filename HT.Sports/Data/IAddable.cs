using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HT.Sports.Data.EF
{
    public interface IAddable<TEntity>
    {
        Task<TEntity> AddAsync(TEntity entity);
    }
}
