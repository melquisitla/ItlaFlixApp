using System;

namespace ItlaFlixApp.WEB.Models.Request
{
    public class RentCreateRequest
    {
        public decimal precio { get; set; }
        public DateTime? fecha { get; set; }
        public bool devuelta { get; set; }
    }
}
