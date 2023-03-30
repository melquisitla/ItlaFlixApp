using ItlaFlixApp.DAL.Models;

namespace ItlaFlixApp.WEB.Models.Responses
{
    public class GenderDetailResponse
    {
        public bool success { get; set; }

        public GenderModel data { get; set; }

        public string message { get; set; }
    }
}
