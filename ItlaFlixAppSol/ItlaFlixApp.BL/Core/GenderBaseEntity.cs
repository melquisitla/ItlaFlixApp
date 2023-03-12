using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ItlaFlixApp.BL.Core
{
    public abstract class GenderBaseEntity
    {
        [Key]
        public int cod_genero { get; set; }
    }
}
