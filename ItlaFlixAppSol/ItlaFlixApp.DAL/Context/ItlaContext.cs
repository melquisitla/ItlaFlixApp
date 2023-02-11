using ItlaFlixApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItlaFlixApp.DAL.Context
{
    public class ItlaContext : DbContext
    {

        public DbSet<User> Users { get; set; }
    }
}
