using System.Collections.Generic;
using ItlaFlixApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItlaFlixApp.DAL.Context
{
    public class ItlaContext : DbContext
    {
        public ItlaContext()
        {

        }
        public ItlaContext(DbContextOptions<ItlaContext> options) : base(options) { }
        //public DbSet<User> Users { get; set; }
        public DbSet<Rent> tAlquilerPeliculas { get; set; }
        public DbSet<Rol> tRols { get; set; }
        public object Users { get; internal set; }
        public IEnumerable<object> Rent { get; internal set; }
    }
}
