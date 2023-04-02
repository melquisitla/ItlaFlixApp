using ItlaFlixApp.DAL.Interfaces;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Context;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace ItlaFlixApp.DAL.Repositorios
{
    public class RentRepositories : Core.RepositoryBase <Rent>, IRentRepository
    {
        private readonly ItlaContext _ItlaContext;
        private readonly ILogger<RentRepositories> _logger;

        public RentRepositories(ItlaContext ItlaContext, ILogger< RentRepositories > logger): base(ItlaContext)
        {
            _ItlaContext = ItlaContext;
            _logger = logger;
        }
        public override void Save(Rent entity)
        {
          
            base.Save(entity);
            base.SaveChanges();
        }
        public override void Remove(Rent entity)
        {
            base.Remove(entity);
            base.SaveChanges();
        }
        public override void Update(Rent entity)
        {
            base.Update(entity);
            base.SaveChanges();

        }
        public override void SaveChanges()
        {
            base.SaveChanges();
        }
        public override List<Rent> GetEntities()
        {
            return this._ItlaContext.tAlquilerPeliculas .ToList();
        }
        public override Rent GetEntity(int id)
        {
            return this._ItlaContext.tAlquilerPeliculas.FirstOrDefault(cd => cd.Id == id);
        }

     

    }
}