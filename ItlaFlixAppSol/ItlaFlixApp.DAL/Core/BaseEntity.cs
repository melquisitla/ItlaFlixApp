
using System.ComponentModel.DataAnnotations;

namespace ItlaFlixApp.DAL.Core
{
    public abstract class BaseEntity
    {
        [Key]
        public int cod_pelicula { get; set; }
       
        public int cod_genero { get; set; }
    }
}
