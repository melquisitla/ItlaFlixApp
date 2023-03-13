using ItlaFlixApp.DAL.Interfaces;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Context;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace ItlaFlixApp.DAL.Repositorios
{
    public class RentRepositories : Core. RepositoryBase <Rent>, IRentRepository
    {
        private readonly ItlaContext _ItlaContext;
        private readonly ILogger<IRentRepository> _logger;

        public RentRepositories(ItlaContext ItlaContext, ILogger< RentRepositories > logger): base(ItlaContext)
        {
            _ItlaContext = ItlaContext;
            _logger = logger;
        }
         
    }
}