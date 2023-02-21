using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Models;
using System.Collections.Generic;

namespace ItlaFlixApp.DAL.Interfaces
{
    public interface ISaleRepository
    {
        List<SaleModel> GetAll();
        void Save(Sale sale);
        void Update(Sale sale);
        void Remove(Sale sale);
        Sale Get(int id);
    }
}
