using System;
using ItlaFlixApp.DAL.Core;

namespace ItlaFlixApp.DAL.Entities
{
    public abstract class User : Rol
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Usuario { get; set; }
        public string? Password { get; set; }
        public string? id_Documento { get; set; }
    }
}
