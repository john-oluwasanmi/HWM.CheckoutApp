using HWM.CheckoutApp.Interfaces.Repository;
using HWM.CheckoutApp.Model;
using System;

namespace HWM.CheckoutApp.Repository
{
    public class OrderRepository : RepositoryBase<Order>,
        IOrderRepository
    {

        //override the base class methods to your specfication 
        //and make a call to the base class methods to perform common CRUD functionalities
        //generics is used to factor out common CRUD functionalities

        public override void Add(Order item)
        {
            Random random = new Random();
            item.OrderID = random.Next(1000); // this is to similate orderId, Ideally it  should increament by 1 in database
            base.Add(item);

        }
    }
}
