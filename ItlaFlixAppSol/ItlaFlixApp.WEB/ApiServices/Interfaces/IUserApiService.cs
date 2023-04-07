using ItlaFlixApp.WEB.Models.Requests;
using ItlaFlixApp.WEB.Models.Responses;
using System.Threading.Tasks;

namespace ItlaFlixApp.WEB.ApiServices.Interfaces
{
    public interface IUserApiService
    {
        Task<UserListResponse> GetUsers();

        Task<UserDetailResponse> GetUser(int id);

        Task<CommadResponse> Update(UserUpdateRequest userUpdate);

        Task<CommadResponse> Save(UserCreateRequest userCreate);
    }
}
