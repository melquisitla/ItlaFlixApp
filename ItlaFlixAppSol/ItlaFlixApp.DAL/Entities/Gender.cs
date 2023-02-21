using ItlaFlixApp.DAL.Core;
using System.ComponentModel.DataAnnotations;

namespace ItlaFlixApp.DAL.Entities
{
    public class Gender
    {
        [Key]
        public int cod_genero { get; set; }

        public string? txt_desc { get; set; }
    }
}
