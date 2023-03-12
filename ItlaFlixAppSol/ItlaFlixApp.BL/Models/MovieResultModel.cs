using ItlaFlixApp.BL.Dtos.Movie;
using System;

namespace ItlaFlixApp.BL.Models
{
    public class MovieResultModel
    {
        [Key]
        public int cod_Peliculas {get;  set;}
        public string txt_desc { get; set; }

        public int cant_disponibles_alquiler { get; set; }

        public int cant_disponibles_venta { get; set; }
        public decimal precio_venta { get; set; }
        public decimal? precio_alquiler { get; set; }

        public DateTime fecha { get; set; }

        public string fechaDisplay
        {
            get { return this.fecha.ToString("dd/MM/yyyy"); }
        
        }
    }
}
