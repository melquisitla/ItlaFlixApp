namespace ItlaFlixApp.WEB.Models.Responses
{
    public class UserDeleteResponse
    {
        public bool success { get; set; }

        public UserModel data { get; set; }

        public string message { get; set; }
    }
}
