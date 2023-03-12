using ItlaFlixApp.BL.Core;
using ItlaFlixApp.BL.Dtos.Movie;

namespace ItlaFlixApp.BL.Contract
{
    public interface IMovieServices : IBaseService
    {
        ServiceResult SaveMovie(MovieSaveDto saveDto);
        ServiceResult UpdateMovie(MovieUpdateDto updateDto);

        ServiceResult RemoveMovie(MovieRemoveDto removeDto);
        
    }
}
