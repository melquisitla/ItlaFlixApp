using System.ComponentModel.DataAnnotations;

namespace ItlaFlixApp.WEB.Models.Requests
{
    public class GenderUpdateRequest
    {


        [Key]
        public int cod_genero { get; set; }
        public string txt_desc { get; set; }
    }
}
