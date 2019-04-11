using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HT.Sports.Data
{
    public interface IUpdateable<TEntity>
    {
        Task<TEntity> UpdateAsync(TEntity entity, Action<TEntity, TEntity> propertyCopyAction);
    }
}
