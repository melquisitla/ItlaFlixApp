using ItlaFlixApp.DAL.Core;

namespace ItlaFlixApp.DAL.Entities
{
    public class Rol : Descripcion
    {
        public int cod_rol { get; set; }
        public int sn_activo { get; set; }
    }
}
