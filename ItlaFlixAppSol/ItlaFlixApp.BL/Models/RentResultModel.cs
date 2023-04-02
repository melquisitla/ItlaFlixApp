using System;
using System.Data;
using ItlaFlixApp.BL.Dtos.Rent;

namespace ItlaFlixApp.BL.Models
{
public class RentResultModel
    {
        [key] 
       
        public int Id { get; set; }
        public int cod_pelicula { get; set; }
        public int cod_usuario { get; set; }
        public decimal precio { get; set; }
        public DateTime? fecha { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Devuelta { get; set; }
    public string CreationDateDisplay 
        {
            get { return this.CreationDate.ToString("dd/MM/yyyy"); }
             }
    }
}
