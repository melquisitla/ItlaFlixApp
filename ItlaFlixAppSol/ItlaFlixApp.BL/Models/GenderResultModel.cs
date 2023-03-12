using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ItlaFlixApp.BL.Models
{
    public class GenderResultModel
    {
        [Key]
        public int cod_genero { get; set; }
        public string? txt_desc { get; set; }

        public DateTime fecha { get; set; }

        public string fechaDisplay
        {
            get { return this.fecha.ToString("dd/MM/yyyy"); }

        }
    }
}
