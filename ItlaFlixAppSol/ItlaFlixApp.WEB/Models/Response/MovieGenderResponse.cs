using System.Collections.Generic;

namespace ItlaFlixApp.WEB.Models.Response
{
    public class MovieGenderResponse
    {
        public bool success { get; set; }

        public List<MoviesGenderModel> data { get; set; }

        public string Message { get; set; }
    }
}
