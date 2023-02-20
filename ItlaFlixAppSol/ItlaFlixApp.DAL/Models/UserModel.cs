namespace ItlaFlixApp.DAL.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Usuario { get; set; }
        public string? Cedula { get; set; }
        public string? Rol { get; set; }
        public bool? Activo { get; set;}

        public UserModel() 
        { 

        }

    }
}
