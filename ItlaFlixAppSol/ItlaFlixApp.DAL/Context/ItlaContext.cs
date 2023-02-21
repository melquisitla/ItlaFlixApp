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
        public DbSet<Movie> tPeliculas { get; set; }

        public DbSet<Gender> tGeneros { get; set; }  
    }
}
