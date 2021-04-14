using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataLayer.Repositories.Abstract
{
    /// <summary>
    /// A generic base interface that contains a CRUD operations contract
    /// </summary>
    /// <typeparam name="TEntity">The class of the entity implemented by the given contract</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> GetAll();
        TEntity GetBy(Func<TEntity,bool> predicate);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);
        IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
