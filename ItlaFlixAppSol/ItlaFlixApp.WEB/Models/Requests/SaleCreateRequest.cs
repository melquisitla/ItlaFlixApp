using System;

namespace ItlaFlixApp.WEB.Models.Requests
{
    public class SaleCreateRequest
    {
        public int cod_pelicula { get; set; }

        public int cod_usuario { get; set; }

        public decimal precio { get; set; }

        public DateTime fecha { get; set; }
    }
}
