using ItlaFlixApp.WEB.Models.Requests;
using ItlaFlixApp.WEB.Models.Responses;
using System.Threading.Tasks;

namespace ItlaFlixApp.WEB.ApiServices.Interfaces
{
    public interface IGenderApiServices
    {
        Task<GenderListResponse> GetGenders();

        Task<GenderDetailResponse> GetGender(int id);

        Task<CommadResponse> Update(GenderUpdateRequest genderUpdate);
        Task<CommadResponse> Save(GenderCreateRequest genderCreate);
    }
}
