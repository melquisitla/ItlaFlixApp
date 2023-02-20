using System;

namespace ItlaFlixApp.DAL.Models
{
    public class SaleModel
    {
        public int? cod_venta { get; set; }
        public string? Titulo { get; set; }
        public string? Usuario  { get; set; }
        public float Precio { get; set;}
        public DateTime Fecha { get; set;}

        public SaleModel() 
        {

        }

    }
}
