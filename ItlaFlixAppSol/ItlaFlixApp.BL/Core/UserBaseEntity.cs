using ItlaFlixApp.BL.Dtos.User;
using System;

namespace ItlaFlixApp.BL.Core
{
    public abstract class UserBaseEntity
    {
        public string? txt_user { get; set; }

        public string? txt_password { get; set; }

        public string? txt_nombre { get; set; }

        public string? txt_apellido { get; set; }

        public string? nro_doc { get; set; }

        public int? cod_rol { get; set; }

        public int? sn_activo { get; set; }
    }
}
