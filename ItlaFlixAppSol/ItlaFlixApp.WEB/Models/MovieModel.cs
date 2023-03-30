﻿using ItlaFlixApp.DAL.Core;
using System.ComponentModel.DataAnnotations;

namespace ItlaFlixApp.WEB.Models
{
    public class MovieModel 

    {
        [Key]
        public int cod_pelicula { get; set; }
        public string txt_desc { get; set; }
       
        public int cant_disponibles_venta { get; set; }
        public int cant_disponibles_alquiler { get; set; }
        public decimal precio_venta { get; set; }
        public decimal? precio_alquiler { get; set; }
    }
}
