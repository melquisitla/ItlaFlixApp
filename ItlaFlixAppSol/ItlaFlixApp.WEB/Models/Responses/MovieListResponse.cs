using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace ItlaFlixApp.WEB.Models.Responses
{
    public class MovieListResponse
    {
        public bool success { get; set; }

        public List<MovieModel> data { get; set; }

        public string message { get; set; }
    }
}
