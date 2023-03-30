using ItlaFlixApp.DAL.Context;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Exceptions;
using ItlaFlixApp.DAL.Interfaces;
using ItlaFlixApp.DAL.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ItlaFlixApp.DAL.Repositorios
{
    public class GenderRepositories : Core.RepositoryBase<Gender>, IGenderRepository
    {

        private readonly ItlaContext itlacontext;
        private readonly ILogger<GenderRepositories> logger;

        public GenderRepositories(ItlaContext itlacontext, ILogger<GenderRepositories> logger) : base(itlacontext) 
        {
            this.itlacontext = itlacontext;
            this.logger = logger;
        }
        public override void Save(Gender entity)
        {
            if (string.IsNullOrEmpty(entity.txt_desc))
            {
                throw new GenderDataException("El nombre es requerido");

            }
            base.Save(entity);
            base.SaveChanges();
        }
        public override void Delete(Gender entity) 
        { 
           base.Delete(entity);
           base.SaveChanges();
        
        }
        public override void Update(Gender entity)
        {
            base.Update(entity);
        }
        public override void SaveChanges()
        {
            base.SaveChanges();
        }
        public override List<Gender> GetEntities() 
        { 
          return this.itlacontext.tGeneros.ToList();
        }

        public override Gender GetEntity(int id)
        {
            return this.itlacontext.tGeneros.FirstOrDefault(cd => cd.cod_genero == id);
        }
    }
}