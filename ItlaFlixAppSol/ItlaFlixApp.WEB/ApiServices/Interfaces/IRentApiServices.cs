using System.Threading.Tasks;
using ItlaFlixApp.WEB.Models.Request;
using ItlaFlixApp.WEB.Models.Response;

namespace ItlaFlixApp.WEB.ApiServices.Interfaces
{
    public interface IRentApiServices
    {
        Task<RentListResponse> GetRents();
      //  Task <RentListResponse> GetRent(int id);
        Task<RentDetailResponse> GetRent(int id);
        Task<CommadResponse> Update(RentUpdateRequest rentUpdate);
        Task<CommadResponse> Save(RentCreateRequest rentCreate);
    }
}
