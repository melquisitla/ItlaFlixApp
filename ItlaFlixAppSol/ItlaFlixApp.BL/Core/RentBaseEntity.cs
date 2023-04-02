using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaFlixApp.BL.Core
{
    public abstract class RentBaseEntity
    {
        //public string txt_desc { get; set; }

        public decimal precio { get; set; }

        public int Id { get; set; }
        public int cod_pelicula { get; set; }
        public int cod_usuario { get; set; }
    }
}