using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace ItlaFlixApp.DAL.Models
{

    public class RolModel
    {
        [Key]
        public int cod_rol { get; set; }
        public string? txt_desc { get; set; }
        public int? sn_activo { get; set; }

    }
}
