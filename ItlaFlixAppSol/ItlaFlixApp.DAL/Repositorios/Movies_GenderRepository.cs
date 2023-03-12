using ItlaFlixApp.DAL.Context;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Interfaces;
using ItlaFlixApp.DAL.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItlaFlixApp.DAL.Repositorios
{
    public class Movies_GenderRepository : Core.RepositoryBase<Movies_Gender>, IMovies_GenderRepository
    {

        private readonly ItlaContext _itlacontext;
        private readonly ILogger<Movies_GenderRepository> _logger;

        public Movies_GenderRepository(ItlaContext itlacontext, ILogger<Movies_GenderRepository> logger) : base(itlacontext) 
        {
            _itlacontext = itlacontext;
            _logger = logger;
        }
        public override void Save(Movies_Gender entity)
        {
            base.Save(entity);
            base.SaveChanges();
        }
        public override void Remove(Movies_Gender entity)
        {
            base.Remove(entity);
            base.SaveChanges();
        }

        public override void Update(Movies_Gender entity)
        {
            base.Update(entity);
            base.SaveChanges();
        }
    }
}
