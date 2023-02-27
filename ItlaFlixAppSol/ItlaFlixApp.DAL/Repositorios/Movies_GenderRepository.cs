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

        //public Movies_GenderRepository()
       // {
        //}

        public Movies_GenderRepository(ItlaContext itlacontext, ILogger<Movies_GenderRepository> logger) : base(itlacontext) 
        {
            _itlacontext = itlacontext;
            _logger = logger;
        }
    }
}
