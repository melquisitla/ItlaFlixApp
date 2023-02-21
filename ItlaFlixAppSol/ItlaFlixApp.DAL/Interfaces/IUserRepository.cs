using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Models;
using System.Collections.Generic;

namespace ItlaFlixApp.DAL.Interfaces
{
    public interface IUserRepository
    {
        List<UserModel> GetAll();
        //void Add(User user);
        void Update(User user);
        void Save(User user);
        void Remove(User user);
        User Get(int id);
        bool Exists(string Name);
    }
}
