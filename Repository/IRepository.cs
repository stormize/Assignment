using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    interface IRepository<TEntity>
    {
        TEntity GetById(object id);
        IQueryable<TEntity> Get(bool allData);

        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity Delete(object id);
    }
}
