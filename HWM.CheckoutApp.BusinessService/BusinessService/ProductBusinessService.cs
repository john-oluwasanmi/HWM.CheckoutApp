using System.Collections.Generic;
using HWM.CheckoutApp.DTO;
using HWM.CheckoutApp.Interfaces.BusinessService;
using HWM.CheckoutApp.Interfaces.Repository;
using HWM.CheckoutApp.Model;

namespace HWM.CheckoutApp.BusinessService
{
    public class ProductBusinessService : BusinessServiceBase<ProductDTO,Product>
        , IProductBusinessService
    {
        public ProductBusinessService(IProductRepository  productRepository  )
             : base(productRepository)
        {

            //override the base class methods to your specfication 
            //and make a call to the base class methods to perform common CRUD functionalities
            //generics is used to factor out common CRUD functionalities
        }


        public override List<ProductDTO> List()
        {
            var products = base.List();
            return products;
        }
    }
}
