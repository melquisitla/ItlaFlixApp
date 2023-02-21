using ItlaFlixApp.DAL.Core;
using System;
using System.Runtime.CompilerServices;

namespace ItlaFlixApp.DAL.Entities
{
    public class Sale 
    {
        public Sale() {
            this.fecha = DateTime.Now;
         }
        public int id { get; set; }
        public int cod_pelicula { get; set; }
        public int cod_usuario { get; set; }
        public decimal precio { get; set; }
        public DateTime fecha { get; set; }
    }
}
