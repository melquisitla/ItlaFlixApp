using ItlaFlixApp.DAL.Models;
using System.Collections.Generic;

namespace ItlaFlixApp.WEB.Models.Responses
{
    public class UserListResponse
    {
        public bool success { get; set; }

        public List<UserModel> data { get; set; }

        public string message { get; set; }
    }
}
