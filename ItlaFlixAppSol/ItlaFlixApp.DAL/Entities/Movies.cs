using ItlaFlixApp.DAL.Core;

namespace ItlaFlixApp.DAL.Entities
{
    public abstract class Movies : BaseEntity
    {
        public string? txt_descripcion { get; set; }
        public int cant_disponible_sale { get; set; }
        public int cant_disponible_rent { get; set; }
        public float precio_sale { get; set; }
        public float precio_rent { get; set; }
    }
}
