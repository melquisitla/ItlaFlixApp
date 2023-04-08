﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaFlixApp.DAL.Models
{
    public class RentModel
    {
        [key]
        public int Id { get; set; }
        public int cod_pelicula { get; set; }
        public int cod_usuario { get; set; }
        public decimal precio { get; set; }
        public DateTime? fecha { get; set; }
        public bool devuelta { get; set; }
    }
}