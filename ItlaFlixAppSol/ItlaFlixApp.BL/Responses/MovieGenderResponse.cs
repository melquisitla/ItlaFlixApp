using ItlaFlixApp.BL.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaFlixApp.BL.Responses
{
    public class MovieGenderResponse : ServiceResult
    {
        public int Cod_genero { get; set; }
    }
}
