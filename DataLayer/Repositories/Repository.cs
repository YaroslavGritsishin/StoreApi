using DataLayer.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataLayer.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext AppContext;
        public Repository(DbContext context)
        {
            AppContext = context;
        }
        public void Add(TEntity entity)
        {
            AppContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            AppContext.Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return AppContext.Set<TEntity>().ToList();
        }

        public TEntity GetBy(Func<TEntity, bool> predicate)
        {
            return AppContext.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Remove(TEntity entity)
        {
            AppContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            AppContext.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            AppContext.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = AppContext.Set<TEntity>().AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
