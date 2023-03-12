using ItlaFlixApp.BL.Dtos.Movie;
using System;

namespace ItlaFlixApp.BL.Dtos.Gender
{
    public class GenderUpdateDto
    {
        [Key]
        public int cod_genero { get; set; }

        public string? txt_desc { get; set; }
    }
}
