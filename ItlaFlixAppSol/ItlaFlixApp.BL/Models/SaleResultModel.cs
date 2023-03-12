using System;

namespace ItlaFlixApp.BL.Models
{
    public class SaleResultModel
    {
        public int Id { get; set; }
        public int cod_pelicula { get; set; }
        public int cod_usuario { get; set; }
        public decimal precio { get; set; }
        public DateTime fecha { get; set; }
        public string fechaDisplay 
        {
            get { return this.fecha.ToString("dd/MM/yyyy"); }
        }
    }
}
