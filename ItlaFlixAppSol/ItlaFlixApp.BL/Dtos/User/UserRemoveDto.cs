using ItlaFlixApp.BL.Core;
using System;

namespace ItlaFlixApp.BL.Dtos.User
{
    public class UserRemoveDto 
    {
        [Key]
        public int cod_usuario { get; set; }

        public bool Removed { get; set; }
    }
}
