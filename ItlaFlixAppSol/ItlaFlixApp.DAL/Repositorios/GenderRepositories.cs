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

        private readonly ItlaContext _itlacontext;
        private readonly ILogger<GenderRepositories> _logger;

        public GenderRepositories(ItlaContext itlacontext, ILogger<GenderRepositories> logger) : base(itlacontext) 
        {
            _itlacontext = itlacontext;
            _logger = logger;
        }
      
    }
}
