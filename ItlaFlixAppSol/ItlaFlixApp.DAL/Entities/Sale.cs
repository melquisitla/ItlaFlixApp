using ItlaFlixApp.DAL.Core;
using System;

namespace ItlaFlixApp.DAL.Entities
{
    public class Sale : Movies
    {
        public Sale() {
            this.Fecha = DateTime.Now;
            this.precio = this.precio_sale;
        }
        public int cod_venta { get; set; }
        //public int cod_usuario { get; set; }
        public float precio { get; set; }
        public DateTime Fecha { get; set; }
    }
}
