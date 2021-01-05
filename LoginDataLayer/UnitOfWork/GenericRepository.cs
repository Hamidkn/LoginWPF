using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LoginDataLayer;

namespace Login.DataLayer.UnitOfWork
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private LoginSignupModel _dbModel;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(LoginSignupModel datasetModel)
        {
            _dbModel = datasetModel;
            _dbSet = _dbModel.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (where != null)
            {
                query = query.Where(where);
            }

            return query.ToList();
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual TEntity GetByID(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbModel.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            if (_dbModel.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        public virtual void Delete(object id)
        {
            // var entity = _dbSet.Find(id);
            // _dbSet.Remove(entity);
            var entity = GetByID(id);
            Delete(entity);
        }
    }
}