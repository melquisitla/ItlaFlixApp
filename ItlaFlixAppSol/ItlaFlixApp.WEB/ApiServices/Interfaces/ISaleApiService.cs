using ItlaFlixApp.WEB.Models.Requests;
using ItlaFlixApp.WEB.Models.Responses;
using System.Threading.Tasks;

namespace ItlaFlixApp.WEB.ApiServices.Interfaces
{
    public interface ISaleApiService
    {
        Task<SaleListResponse> GetSales();

        Task<SaleDetailResponse> GetSale(int id);

        Task<CommadResponse> Update(SaleUpdateRequest saleUpdate);

        Task<CommadResponse> Save(SaleCreateRequest saleCreate);
    }
}
