using ItlaFlixApp.DAL.Core;

namespace ItlaFlixApp.DAL.Entities
{
    public abstract class Movies : BaseEntity
    {
        public string? txt_descripcion { get; set; }
        public int? cant_disponibles_venta { get; set; }
        public int? cant_disponibles_alquiler { get; set; }
        public decimal precio { get; set; }
    }
}
