using ItlaFlixApp.DAL.Core;

namespace ItlaFlixApp.WEB.Models
{
    public class MovieModel : BaseEntity

    {
        public int id { get; set; }
        public string Pelicula { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public int cant_disponible_sale { get; set; }
        public int cant_disponible_rent { get; set; }
        public float precio_sale { get; set; }
        public float precio_rent { get; set; }

        public MovieModel() {
        
        }
    }
}
