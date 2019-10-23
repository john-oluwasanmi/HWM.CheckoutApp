using HWM.CheckoutApp.DTO;
using HWM.CheckoutApp.Interfaces.BusinessService;
using HWM.CheckoutApp.Interfaces.Repository;
using HWM.CheckoutApp.Model;

namespace HWM.CheckoutApp.BusinessService
{
    public class OrderBusinessService : BusinessServiceBase<OrderDTO, Order>
        , IOrderBusinessService
    {
        public OrderBusinessService(IOrderRepository orderRepository)
              : base(orderRepository)
        {
        }
    }
}
