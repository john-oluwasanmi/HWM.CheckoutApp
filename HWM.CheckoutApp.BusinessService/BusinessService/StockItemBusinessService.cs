using HWM.CheckoutApp.BusinessService;
using HWM.CheckoutApp.Interfaces.BusinessService;
using HWM.CheckoutApp.Interfaces.Repository;

namespace HWM.CheckoutApp.Model
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
