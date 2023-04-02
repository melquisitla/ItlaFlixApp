using System.Collections.Generic;

namespace ItlaFlixApp.WEB.Models.Response
{
    public class RentDetailResponse
    {
        public bool sucess { get; set; }
        public RentModel data { get; set; }
        public string message { get; set; }
    }
}
