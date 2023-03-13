using ItlaFlixApp.DAL.Context;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace ItlaFlixApp.DAL.Repositorios
{
    public class SaleRepositories : Core.RepositoryBase<Sale>, ISaleRepository
    {
        private readonly ItlaContext ItlaContext;
        private readonly ILogger<SaleRepositories> logger;

        public SaleRepositories(ItlaContext ItlaContext, ILogger<SaleRepositories> logger): base(ItlaContext)
        {
            this.ItlaContext = ItlaContext;
            this.logger = logger;
        }

        public override void Save(Sale entity)
        {
            // x logica para verificar //
            base.Save(entity);
            base.SaveChanges();
        }

        public override void Update(Sale entity)
        {
            base.Update(entity);
            base.SaveChanges();
        }

        public override void Remove(Sale entity)
        {
            base.Remove(entity);
            base.SaveChanges();
        }

        public override List<Sale> GetEntities()
        {
            return this.ItlaContext.tVentaPeliculas.ToList();
        }
        public override Sale GetEntity(int id)
        {
            return this.ItlaContext.tVentaPeliculas.FirstOrDefault(cd => cd.id == id);
        }
    }
}
