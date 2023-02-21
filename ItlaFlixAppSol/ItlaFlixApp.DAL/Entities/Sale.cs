using ItlaFlixApp.DAL.Core;
using System;

namespace ItlaFlixApp.DAL.Entities
{
    public  class Sale : Movie
    {
        public Sale() {
            this.Fecha = DateTime.Now;
            this.Precio = this.precio_venta;
        }
        public int cod_venta { get; set; }
        //public int cod_usuario { get; set; }
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }
    }
}
