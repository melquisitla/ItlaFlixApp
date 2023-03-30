namespace ItlaFlixApp.WEB.Models.Responses
{
    public class MovieDetailResponse
    {
        public bool success { get; set; }

        public MovieModel data { get; set; }

        public string message { get; set; }
    }
}
