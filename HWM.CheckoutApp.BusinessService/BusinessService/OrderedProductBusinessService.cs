﻿using HWM.CheckoutApp.DTO;
using HWM.CheckoutApp.Interfaces.BusinessService;
using HWM.CheckoutApp.Interfaces.Repository;
using HWM.CheckoutApp.Model;

namespace HWM.CheckoutApp.BusinessService
{
    public class OrderedProductBusinessService : BusinessServiceBase<OrderedProductDTO, OrderedProduct>
            , IOrderedProductBusinessService
    {
        public OrderedProductBusinessService(IOrderedProductRepository orderedProductRepository)
              : base(orderedProductRepository)
        {
            //override the base class methods to your specfication 
            //and make a call to the base class methods to perform common CRUD functionalities
            //generics is used to factor out common CRUD functionalities
        }
    }
}
