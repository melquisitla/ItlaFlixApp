namespace ItlaFlixApp.WEB.Models.Responses
{
    public class SaleDetailResponse
    {
        public bool success { get; set; }

        public SaleModel data { get; set; }

        public string message { get; set; }
    }
}
