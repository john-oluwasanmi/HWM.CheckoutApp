using HWM.CheckoutApp.Interfaces.Repository;
using HWM.CheckoutApp.Model;

namespace HWM.CheckoutApp.Repository
{
    public class OrderRepository : RepositoryBase<Order>,
        IOrderRepository
    {

        //override the base class methods to your specfication 
        //and make a call to the base class methods to perform common CRUD functionalities
        //generics is used to factor out common CRUD functionalities
    }
}
