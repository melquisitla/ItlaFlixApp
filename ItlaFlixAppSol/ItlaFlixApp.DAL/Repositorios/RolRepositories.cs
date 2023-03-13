using ItlaFlixApp.DAL.Interfaces;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Context;
using Microsoft.Extensions.Logging;


namespace ItlaFlixApp.DAL.Repositorios
{
    public class RolRepositories : Core. RepositoryBase <Rol>,IRolRepository
    {
        private readonly ItlaContext _ItlaContext;
        private readonly ILogger<IRolRepository> _logger;

        public RolRepositories(ItlaContext Itlacontext, 
                               ILogger<RolRepositories> logger) : base( Itlacontext) 
        {
            this._ItlaContext = Itlacontext;
            this._logger = logger;
        }

    }
}
