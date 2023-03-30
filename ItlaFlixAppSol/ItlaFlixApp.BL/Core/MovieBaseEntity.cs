using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaFlixApp.BL.Core
{
    public abstract class MovieBaseEntity
    {
        public string txt_desc { get; set; }

        public decimal precio_venta { get; set; }
        public decimal precio_alquiler { get; set; }

        public int cant_disponibles_venta { get; set; }
        public int cant_disponibles_alquiler { get; set; }
    }
}

