using ItlaFlixApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace ItlaFlixApp.DAL.Context
{
    public class ItlaContext : DbContext
    {

        public ItlaContext()
        { 
        
        }

        public ItlaContext(DbContextOptions<ItlaContext> options) : base(options)
        {

        }
/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasNoKey();
        }*/
        #region "Sales"
        public DbSet<Sale> tVentaPeliculas { get; set; }
        public DbSet<User> tUsers { get; set; }
        #endregion
    }
}
