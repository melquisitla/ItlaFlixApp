﻿using ItlaFlixApp.BL.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaFlixApp.BL.Dtos.Movie
{
    public class MovieSaveDto : MovieBaseEntity
    {


        [Key]
        public int cod_pelicula { get; set; }
    }
}