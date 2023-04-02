using System.Collections.Generic;

namespace ItlaFlixApp.WEB.Models.Response
{
    public class RentListResponse
    {
    public bool sucess { get; set; }
    public List <RentModel> data { get; set; }
    public string message { get; set; } 
    }
}
