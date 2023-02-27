using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ItlaFlixApp.DAL.Core
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Save(TEntity entity);

        void Save(TEntity[] entities);//Sobrecarga de Metodo Save

        void Update(TEntity entity);

        void Update(TEntity[] entities);//Sobrecarga de Metodo Update

        void Remove(TEntity entity);

        void Remove(TEntity[] entities);//Sobrecarga de Metodo Remove

        TEntity GetEntity(int id);
        
        List<TEntity> GetEntities();

        bool Exist(Expression<Func<TEntity, bool>> filter);

        void SaveChanges();
    }
}
