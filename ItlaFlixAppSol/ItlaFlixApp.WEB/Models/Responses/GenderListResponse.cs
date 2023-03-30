using System.Collections.Generic;

namespace ItlaFlixApp.WEB.Models.Responses
{
    public class GenderListResponse
    {
        public bool success { get; set; }

        public List<GenderModel> data { get; set; }

        public string message { get; set; }
    }
}
