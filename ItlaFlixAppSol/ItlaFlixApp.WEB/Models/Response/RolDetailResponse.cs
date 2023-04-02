using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItlaFlixApp.WEB.Models.Response
{
    public class RolDetailResponse
    {
        public bool sucess { get; set; }
        public List<RentModel> data { get; set; }
        public string message { get; set; }

    }
}
