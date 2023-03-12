using ItlaFlixApp.BL.Core;
using System;

namespace ItlaFlixApp.BL.Dtos.User
{
    public class UserUpdateDto : UserBaseEntity
    {
        [Key]
        public int cod_usuario { get; set; }
    }
}
