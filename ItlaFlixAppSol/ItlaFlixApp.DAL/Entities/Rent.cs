using ItlaFlixApp.DAL.Core;
using System;

namespace ItlaFlixApp.DAL.Entities
{
    public class Rent
    {
        public Rent()
        {
            this.fecha = DateTime.Now;
            this.devuelta = false;
        }
        public int Id { get; set; }
        public int cod_pelicula { get; set; }
        public int cod_usuario { get; set; }
        public decimal precio { get; set; }
        public DateTime fecha { get; set; }
        public bool devuelta { get; set; }
        //public DateTime? Date_Devuelta { get; set; }
        public int? cod_usuario_devolucion { get; set; }
    }
}
