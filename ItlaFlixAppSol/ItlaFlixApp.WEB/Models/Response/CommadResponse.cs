﻿using System.Collections.Generic;

namespace ItlaFlixApp.WEB.Models.Response
{
    public class CommadResponse
    {
        public bool success { get; set; }
        public dynamic data { get; set; }
        public string message { get; set; }
    }
}
