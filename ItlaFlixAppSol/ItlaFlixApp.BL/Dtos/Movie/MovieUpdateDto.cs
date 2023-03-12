using ItlaFlixApp.BL.Core;
using System;

namespace ItlaFlixApp.BL.Dtos.Movie
{
    public class MovieUpdateDto : MovieBaseEntity
    {
        [Key]
        public int cod_pelicula { get; set; }
    
    }
}
