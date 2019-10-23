using HWM.CheckoutApp.BusinessService;
using HWM.CheckoutApp.Interfaces.BusinessService;
using HWM.CheckoutApp.Interfaces.Repository;

namespace HWM.CheckoutApp.Model
{
    public class OrderedProductBusinessService : BusinessServiceBase<OrderedProductDTO, OrderedProduct>
            , IOrderedProductBusinessService
    {
        public OrderedProductBusinessService(IOrderedProductRepository orderedProductRepository)
              : base(orderedProductRepository)
        {
        }
    }
}
