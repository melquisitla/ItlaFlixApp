using ItlaFlixApp.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ItlaFlixApp.DAL.Core
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ItlaContext context;//Fill
        private readonly DbSet<TEntity> myDbSet;

        public RepositoryBase(ItlaContext context) 
        {
            this.context = context;
            this.myDbSet = this.context.Set<TEntity>();//Agrega el TEntity al DbContext
        }

        public virtual bool Exist(Expression<Func<TEntity, bool>> filter)//Metodo de Sobreescritura Virtual
        {
            return this.myDbSet.Any(filter);
        }

        public virtual List<TEntity> GetEntities()//Metodo de Sobreescritura Virtual
        {   
            return myDbSet.ToList();
        }

        public virtual TEntity GetEntity(int id)//Metodo de Sobreescritura Virtual
        {
            return myDbSet.Find(id);
        }

        public virtual void Remove(TEntity entity)//Metodo de Sobreescritura Virtual
        {
            this.myDbSet.Remove(entity);
        }

        public virtual void Remove(TEntity[] entities)//Metodo de Sobreescritura Virtual
        {
            this.myDbSet.RemoveRange(entities);
        }

        public virtual void Save(TEntity entity)//Metodo de Sobreescritura Virtual
        {
            this.myDbSet.Add(entity);
        }

        public virtual void Save(TEntity[] entities)//Metodo de Sobreescritura Virtual
        {
            this.myDbSet.AddRange(entities);
        }

        public virtual void Update(TEntity entity)//Metodo de Sobreescritura Virtual
        {
            this.myDbSet.Update(entity);
        }

        public virtual void Update(TEntity[] entities)//Metodo de Sobreescritura Virtual
        {
            this.myDbSet.AddRange(entities);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
