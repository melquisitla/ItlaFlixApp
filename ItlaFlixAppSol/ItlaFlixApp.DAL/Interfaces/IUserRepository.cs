using ItlaFlixApp.DAL.Entities;
using System.Collections.Generic;

namespace ItlaFlixApp.DAL.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        List<User> GetAll();
        User UserGet(int id);
    }
}
