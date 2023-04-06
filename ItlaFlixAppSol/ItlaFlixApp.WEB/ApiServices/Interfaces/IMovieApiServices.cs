using ItlaFlixApp.WEB.Models.Requests;
using ItlaFlixApp.WEB.Models.Responses;
using System.Threading.Tasks;

namespace ItlaFlixApp.WEB.ApiServices.Interfaces
{
    public interface IMovieApiServices
    {
        Task<MovieListResponse> GetMovies();

        Task<MovieDetailResponse> GetMovie(int id);

        Task<CommadResponse> Update(MovieUpdateRequest movieUpdate);
        Task<CommadResponse> Save(MovieCreateRequest movieCreate);
    }
}
