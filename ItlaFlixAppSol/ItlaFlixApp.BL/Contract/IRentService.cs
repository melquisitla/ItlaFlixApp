using System;
using ItlaFlixApp.BL.Core;
using ItlaFlixApp.BL.Dtos.Rent;


namespace ItlaFlixApp.BL.Contract
{
    public interface IRentService : IBaseService
    {

        ServiceResult SaveRent(RentSaveDto saveDto);
        ServiceResult UpdateRent (RentUpdateDto updateDto);
        ServiceResult RemoveRent (RentRemoveDto removeDto);
    }
}