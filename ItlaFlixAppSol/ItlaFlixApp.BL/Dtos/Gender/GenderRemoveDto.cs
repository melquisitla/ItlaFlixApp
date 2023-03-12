using ItlaFlixApp.BL.Dtos.Movie;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaFlixApp.BL.Dtos.Gender
{
    public class GenderRemoveDto
    {
        [Key]
        public int cod_genero { get; set; }

        public bool Removed { get; set; }
    }
}
