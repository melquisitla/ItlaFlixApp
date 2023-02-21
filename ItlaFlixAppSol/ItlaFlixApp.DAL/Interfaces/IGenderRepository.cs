using ItlaFlixApp.DAL.Entities;
using System.Collections.Generic;
using ItlaFlixApp.DAL.Models;
namespace ItlaFlixApp.DAL.Interfaces
{
    public interface IGenderRepository
    {
        void Add(Gender gender);
        void Update(Gender gender);
        void Delete(Gender gender);

        Gender Get(int id);
        bool Exists(string txt_desc);

        List<GenderModel> GetAll();
        
    }
}
