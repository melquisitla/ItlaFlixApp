using System;
using System.Collections.Generic;

namespace ItlaFlixApp.WEB.Models.Response
{
    public class RentListResponse
    {
        public bool success { get; set; }
        public List <RentModel> data { get; set; }
        public string message { get; set; }
    }
}
