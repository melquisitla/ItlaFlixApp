using ItlaFlixApp.BL.Core;
using ItlaFlixApp.BL.Dtos.Gender;

namespace ItlaFlixApp.BL.Contract
{
    public interface IGenderServices : IBaseService
    {
        ServiceResult SaveGender(GenderSaveDto saveDto);

        ServiceResult UpdateGender(GenderUpdateDto updateDto);

        ServiceResult RemoveGender(GenderRemoveDto removeDto);
       
    }
}
