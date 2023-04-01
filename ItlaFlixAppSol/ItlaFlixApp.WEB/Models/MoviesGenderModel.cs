using System.ComponentModel.DataAnnotations;

namespace ItlaFlixApp.WEB.Models
{
    public class MoviesGenderModel
    {
        [Key] public int Cod_genero { get; set; }
        public int Cod_pelicula { get; set; }
    }
}
