using HWM.CheckoutApp.BusinessService;
using HWM.CheckoutApp.Interfaces.BusinessService;
using HWM.CheckoutApp.Interfaces.Repository;

namespace HWM.CheckoutApp.Model
{
    public class OrderBusinessService : BusinessServiceBase<OrderDTO, Order>, IOrderBusinessService
    {
        public OrderBusinessService(IOrderRepository orderRepository)
              : base(orderRepository)
        {
        }
    }
}
