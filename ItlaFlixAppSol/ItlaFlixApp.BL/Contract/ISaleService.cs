using ItlaFlixApp.BL.Core;
using ItlaFlixApp.BL.Dtos.Sale;

namespace ItlaFlixApp.BL.Contract
{
    public interface ISaleService : IBaseService
    {
        ServiceResult SaveSale(SaleSaveDto saveDto);

        ServiceResult UpdateSale(SaleUpdateDto updateDto);

        ServiceResult RemoveSale(SaleRemoveDto removeDto);
    }
}
