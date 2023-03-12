using ItlaFlixApp.BL.Core;
using ItlaFlixApp.BL.Dtos.User;

namespace ItlaFlixApp.BL.Contract
{
    public interface IUserService : IBaseService
    {
        ServiceResult SaveUser(UserSaveDto saveDto);

        ServiceResult UpdateUser(UserUpdateDto updateDto);

        ServiceResult RemoveUser(UserRemoveDto removeDto);
    }
}
