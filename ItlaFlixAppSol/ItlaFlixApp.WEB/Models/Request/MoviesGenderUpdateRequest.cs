using System.ComponentModel.DataAnnotations;

namespace ItlaFlixApp.WEB.Models.Request
{
    public class MoviesGenderUpdateRequest
    {
        [Key] public int Cod_genero { get; set; }
        public int Cod_Pelicula { get; set; }
    }
}
