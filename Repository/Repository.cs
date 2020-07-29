using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class Repository<TContext, TEntity> : IRepository<TEntity>
        where TEntity : class where TContext : DbContext
    {
        readonly DbSet<TEntity> _dbSet;
        readonly TContext _context;
        public Repository(TContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public TEntity Create(TEntity entity)
        {
            TEntity result;
            try
            {
                result = _dbSet.Add(entity);
            }
            catch
            {
                return null;
            }
            return result;



        }

        public TEntity Delete(object id)
        {
            TEntity entity = GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
                return entity;
            }
            return null;
        }

        public IQueryable<TEntity> Get(bool allData = false)
        {
            if (allData)
            {
                return _dbSet;
            }
            return _dbSet;
        }

        abstract public TEntity GetById(object id);



        public TEntity Update(TEntity entity)
        {

            _dbSet.Attach(entity);
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            return entity;

        }

    }
}
