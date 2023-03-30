using ItlaFlixApp.DAL.Models;
using System.Collections.Generic;
using System.Security.Policy;

namespace ItlaFlixApp.WEB.Models.Responses
{
    public class SaleListResponse
    {
        public bool success { get; set; }

        public List<SaleModel> data { get; set; }

        public string message { get; set; }
    }
}
