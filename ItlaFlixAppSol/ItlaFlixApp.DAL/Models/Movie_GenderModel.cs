using ItlaFlixApp.DAL.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ItlaFlixApp.DAL.Model
{
    public class Movie_GenderModel : BaseEntity {
        [Key]
        public int cod_genero { get; set; }

        public int cod_pelicula { get; set; }
    }
}
