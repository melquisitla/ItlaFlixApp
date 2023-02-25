using ItlaFlixApp.DAL.Core;
using System.ComponentModel.DataAnnotations;

namespace ItlaFlixApp.DAL.Entities
{
    public class Movies_Gender 
    {
        [Key]
        public int cod_genero { get; set; }
        public int cod_pelicula { get; set; }
    }
}
