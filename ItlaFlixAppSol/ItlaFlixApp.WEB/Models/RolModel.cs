using System.ComponentModel.DataAnnotations;

namespace ItlaFlixApp.WEB.Models
{
    public class RolModel
    {
        [Key]
        public int cod_rol { get; set; }
        public string? txt_desc { get; set; }
        public int? sn_activo { get; set; }

    }
}
