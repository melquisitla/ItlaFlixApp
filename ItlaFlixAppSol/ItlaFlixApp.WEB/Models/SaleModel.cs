using System;

namespace ItlaFlixApp.WEB.Models
{
    public class SaleModel
    {
        public int id { get; set; }

        public int cod_pelicula { get; set; }

        public int cod_usuario { get; set; }

        public decimal precio { get; set; }

        public DateTime fecha { get; set; }
    }
}
