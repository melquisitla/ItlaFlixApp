using ItlaFlixApp.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ItlaFlixApp.DAL.Core
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ItlaContext context;
        private readonly DbSet<TEntity> myDBset;


        public RepositoryBase(ItlaContext context)
        {
            this.context = context;
            this.myDBset = this.context.Set<TEntity>();
        }
        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.myDBset.Any(filter);
        }

        public virtual List<TEntity> GetEntities()
        {
            return this.myDBset.ToList();
        }

        public virtual TEntity GetEntity(int id)
        {
            return this.myDBset.Find(id);
        }

        public virtual void Remove(TEntity entity)
        {
            this.myDBset.Remove(entity);
        }

        public virtual void Remove(TEntity[] entities)
        {
            this.myDBset.RemoveRange(entities);
        }

        public virtual void Save(TEntity entity)
        {
            this.myDBset.Add(entity);
        }

        public virtual void Save(TEntity[] entities)
        {
            this.myDBset.AddRange(entities);
        }

        public virtual void SaveChanges()
        {
           this.context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            this.myDBset.Update(entity);
        }

        public virtual void Update(TEntity[] entities)
        {
            this.myDBset.UpdateRange(entities);
        }
    }
}
