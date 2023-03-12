using ItlaFlixApp.DAL.Context;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Interfaces;
using Microsoft.Extensions.Logging;


namespace ItlaFlixApp.DAL.Repositorios
{
    public class MovieRepositories : Core.RepositoryBase<Movie>,IMovieRepository

    {


        private readonly ItlaContext _itlacontext;
        private readonly ILogger<MovieRepositories> _logger;

        public MovieRepositories(ItlaContext itlacontext, ILogger<MovieRepositories> logger) : base(itlacontext) 
        {
            _itlacontext = itlacontext;
            _logger = logger;
        }

        public override void Add(Movie entity)
        {
            base.Add(entity);   
            base.SaveChanges();
        }
    }
}

