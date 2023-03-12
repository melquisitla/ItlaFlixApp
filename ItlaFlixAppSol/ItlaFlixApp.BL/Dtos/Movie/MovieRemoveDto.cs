using ItlaFlixApp.BL.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaFlixApp.BL.Dtos.Movie
{
    public class MovieRemoveDto 
    {
        [Key]
        public int cod_pelicula { get; set; }

        public bool Removed { get; set; }

        public bool Deleted { get; set; }

      
    }
}
