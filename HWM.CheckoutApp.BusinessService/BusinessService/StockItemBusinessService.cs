using HWM.CheckoutApp.DTO;
using HWM.CheckoutApp.Interfaces.BusinessService;
using HWM.CheckoutApp.Interfaces.Repository;
using HWM.CheckoutApp.Model;

namespace HWM.CheckoutApp.BusinessService
{
    public class StockItemBusinessService : BusinessServiceBase<StockItemDTO, StockItem>
        , IStockItemBusinessService
    {
        public StockItemBusinessService(IStockItemRepository stockItemRepository)
               : base(stockItemRepository)
        {

        }
    }
}
