using System;

namespace ItlaFlixApp.BL.Core
{
    public abstract class SaleBaseEntity
    {
        public int cod_pelicula { get; set; }

        public int cod_usuario { get; set; }

        public decimal precio { get; set; }

        public DateTime fecha { get; set; }
    }
}
