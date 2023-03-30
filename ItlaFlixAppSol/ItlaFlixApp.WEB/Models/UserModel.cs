using System.ComponentModel.DataAnnotations;

namespace ItlaFlixApp.WEB.Models
{
    public class UserModel
    {
        [Key]
        public int cod_usuario { get; set; }
        public string? txt_nombre { get; set; }
        public string? txt_apellido { get; set; }
        public string? txt_user { get; set; }
        public string? nro_doc { get; set; }
        public int? cod_rol { get; set; }
        public int? sn_activo { get; set; }
        public string FullName
        {
            get
            {
                return string.Concat(txt_nombre, " ", txt_apellido);
            }
        }

    }
}
