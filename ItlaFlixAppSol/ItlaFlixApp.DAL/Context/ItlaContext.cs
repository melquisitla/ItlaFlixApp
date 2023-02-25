using ItlaFlixApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItlaFlixApp.DAL.Context
{
    public class ItlaContext : DbContext
    {

        public ItlaContext() { }
        public ItlaContext(DbContextOptions<ItlaContext> options) : base(options)
        {

        }
        public DbSet<Movies_Gender> tGeneroPelicula { get; set; }
        //public DbSet<User> Users { get; set; }


    }
}
