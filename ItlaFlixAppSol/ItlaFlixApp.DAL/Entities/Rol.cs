using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ItlaFlixApp.DAL.Core;

namespace ItlaFlixApp.DAL.Entities
{
    public class Rol
    {
        [Key]
        public int cod_rol { get; set; }
        public string? txt_desc { get; set; }

        public int? sn_activo { get; set; }
    }
}
