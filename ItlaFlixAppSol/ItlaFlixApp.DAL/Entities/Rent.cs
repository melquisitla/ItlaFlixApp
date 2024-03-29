﻿using ItlaFlixApp.DAL.Core;
using System;

namespace ItlaFlixApp.DAL.Entities
{
    public class Rent : Movies
    {
        public Rent() {
            this.Fecha = DateTime.Now;
            this.Devuelta = false;
            this.precio = this.precio_rent;
        }
        public int cod_rent { get; set; }      
        //public int cod_usuario { get; set; }
        public float precio { get; set; }
        public DateTime Fecha { get; set; }
        public bool Devuelta { get; set; }
        public DateTime Date_Devuelta { get; set; }
        public int cod_usuario_devolucion { get; set; }
    }
}
