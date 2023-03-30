using ItlaFlixApp.DAL.Context;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ItlaFlixApp.DAL.Exceptions;
using System.Linq;

namespace ItlaFlixApp.DAL.Repositorios
{
    public class MovieRepositories : Core.RepositoryBase<Movie>,IMovieRepository

    {


        private readonly ItlaContext itlacontext;
        private readonly ILogger<MovieRepositories> logger;

        public MovieRepositories(ItlaContext itlacontext, ILogger<MovieRepositories> logger) : base(itlacontext) 
        {
            this.itlacontext = itlacontext;
            this.logger = logger;
        }

        public override void Save(Movie entity)
        {
            if (string.IsNullOrEmpty(entity.txt_desc)) 
            {
                throw new MovieDataException("El nombre es requerido");
            
            }
            base.Save(entity);   
            base.SaveChanges();
        }
        public override void Delete(Movie entity) 
        {
           base.Delete(entity);
            base.SaveChanges();
        }
        public override void Update(Movie entity) 
        {
           base.Update(entity);
            base.SaveChanges();
        
        }
        public override void SaveChanges()
        {
            base.SaveChanges();
        }
        public override List<Movie> GetEntities() 
        {
            return this.itlacontext.tPeliculas.ToList();
        }
        public override Movie GetEntity(int id)
        {
            return this.itlacontext.tPeliculas.FirstOrDefault(cd => cd.cod_pelicula == id);
        }
    }
}

