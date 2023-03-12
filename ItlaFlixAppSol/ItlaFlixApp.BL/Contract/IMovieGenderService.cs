using ItlaFlixApp.BL.Core;
using ItlaFlixApp.BL.Dtos.MovieGender;
using ItlaFlixApp.BL.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItlaFlixApp.BL.Contract
{
    public interface IMovieGenderService : IBaseService
    {
        ServiceResult SaveMovieGender(MovieGenderSaveDto saveDto);
        ServiceResult UpdateMovieGender(MovieGenderUpdateDto updateDto);
        ServiceResult DeleteMovieGender(MovieGenderRemoveDto removeDto);
    }
}
