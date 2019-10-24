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
            //override the base class methods to your specfication 
            //and make a call to the base class methods to perform common CRUD functionalities
            //generics is used to factor out common CRUD functionalities
        }
    }
}
