

using System.ComponentModel.DataAnnotations;

namespace ItlaFlixApp.DAL.Models
{
    public class GenderModel
    {
        [Key]
        public int cod_genero { get; set; }
        public string? txt_desc { get; set; }




    }
}
