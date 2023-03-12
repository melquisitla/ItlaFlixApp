using ItlaFlixApp.BL.Core;
using ItlaFlixApp.BL.Dtos.Movie;
using System;

namespace ItlaFlixApp.BL.Dtos.Gender
{
    public class GenderUpdateDto : GenderBaseEntity
    {
       public string? txt_desc { get; set; }
    }
}
