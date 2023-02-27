using ItlaFlixApp.DAL.Context;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace ItlaFlixApp.DAL.Repositorios
{
    public class SaleRepositories : Core.RepositoryBase<Sale>, ISaleRepository
    {
        private readonly ItlaContext _ItlaContext;
        private readonly ILogger<SaleRepositories> _logger;

        public SaleRepositories(ItlaContext ItlaContext, ILogger<SaleRepositories> logger): base(ItlaContext)
        {
            _ItlaContext = ItlaContext;
            _logger = logger;
        }
    }
}
