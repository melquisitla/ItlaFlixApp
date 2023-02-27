
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ItlaFlixApp.DAL.Core
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Add(TEntity[] entities);
        void Delete(TEntity entity);
        void Delete(TEntity[] entities);
        void Update(TEntity entity);
        void Update(TEntity[] entities);
        void Save(TEntity entity);
        void Save(TEntity[] entities);

        TEntity GetEntity(int id);

        List<TEntity> GetEntities();

        bool Exists(Expression<Func<TEntity, bool>> filter);

        void SaveChanges();
    }
}
