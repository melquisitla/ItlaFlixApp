using ItlaFlixApp.BL.Core;
using ItlaFlixApp.BL.Dtos.Movie;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaFlixApp.BL.Dtos.Gender
{
    public class GenderRemoveDto : GenderBaseEntity
    {
         public bool Removed { get; set; }
    }
}
