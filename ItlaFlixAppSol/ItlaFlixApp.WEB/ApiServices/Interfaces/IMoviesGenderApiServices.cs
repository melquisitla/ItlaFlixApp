using ItlaFlixApp.WEB.Models.Request;
using ItlaFlixApp.WEB.Models.Response;
using System.Threading.Tasks;

namespace ItlaFlixApp.WEB.ApiServices.Interfaces
{
    public interface IMoviesGenderApiServices
    {
        Task<MovieGenderResponse> GetMoviesGender();

        Task<MovieGenderResponse> GetMovieGender(int id);

        Task<CommadResponse> UpdateMovieGender(MoviesGenderUpdateRequest movieGender);
    }
}
