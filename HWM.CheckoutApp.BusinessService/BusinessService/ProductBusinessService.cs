using HWM.CheckoutApp.BusinessService;
using HWM.CheckoutApp.Interfaces.BusinessService;
using HWM.CheckoutApp.Interfaces.Repository;

namespace HWM.CheckoutApp.Model
{
    public class ProductBusinessService : BusinessServiceBase<ProductDTO,Product>
        , IProductBusinessService
    {
        public ProductBusinessService(IProductRepository  productRepository  )
             : base(productRepository)
        {
        }
    }
}
