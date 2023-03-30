namespace ItlaFlixApp.WEB.Models.Responses
{
    public class SaleDeleteResponse
    {
        public bool success { get; set; }

        public SaleModel data { get; set; }

        public string message { get; set; }
    }
}
