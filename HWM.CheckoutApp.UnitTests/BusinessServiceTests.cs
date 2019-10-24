using HWM.CheckoutApp.BusinessService;
using HWM.CheckoutApp.DTO;
using HWM.CheckoutApp.Interfaces.BusinessService;
using HWM.CheckoutApp.Interfaces.Repository;
using HWM.CheckoutApp.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace HWM.CheckoutApp.UnitTests
{
    [TestClass]
    public class BusinessServiceTests
    {

        IOrderBusinessService _orderBusinessService;
        List<Order> _orders;

        [TestInitialize]
        public void Setup()
        {
            var mockOrderRepository = new Mock<IOrderRepository>();

            _orders = new List<Order> { };

            mockOrderRepository.Setup(r => r.Add(It.IsAny<Order>()))
                                .Callback<Order>(c => _orders.Add(new Order
                                {
                                    OrderDate = DateTime.Now,
                                }));

            mockOrderRepository.Setup(r => r.Get(It.IsAny<int>())).Returns(new Order
            {
                OrderDate = DateTime.Now,
                OrderID = 1
            });

            mockOrderRepository.Setup(r => r.List()).Returns(_orders);

            _orderBusinessService = new OrderBusinessService(mockOrderRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Invalid Order item")]
        public void WhenAddedOrderIsNullThen_ThrowExecption()
        {
            OrderDTO order = null;
            _orderBusinessService.Add(order);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid OrderId")]
        public void WhenAddedOrderHasIDThen_ThrowExecption()
        {
            OrderDTO order = new OrderDTO { OrderID = 1 };
            _orderBusinessService.Add(order);
        }

        [TestMethod]
        public void WhenAddedOrderThen_ListCountIncreased()
        {
            OrderDTO order = new OrderDTO { CreatedOn = DateTime.Now };
            _orderBusinessService.Add(order);

            Assert.IsTrue(_orders.Count == 1);
        }

        [TestMethod]
        public void WhenListOrderThen_OrderListRetured()
        {
            OrderDTO order = new OrderDTO { CreatedOn = DateTime.Now };

            _orderBusinessService.Add(order);
            var orders = _orderBusinessService.List();

            Assert.IsTrue(orders.Count == _orders.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid  OrderId")]
        public void WhenUpdateOrderWithNoIdThen_ThrowExecption()
        {
            OrderDTO order = new OrderDTO { };
            _orderBusinessService.Update(order);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Invalid Order item")]
        public void WhenUpdateOrderIsNullThen_ThrowExecption()
        {
            OrderDTO order = null;
            _orderBusinessService.Update(order);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid  OrderId")]
        public void WhenDeleteOrderWithNoIdThen_ThrowExecption()
        {
            _orderBusinessService.Delete(0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Invalid  OrderId")]
        public void WhenGetOrderWithNoIdThen_ThrowExecption()
        {
            _orderBusinessService.Get(0);
        }

        [TestMethod]
        public void WhenGetOrderWithIdThen_ReturnOrder()
        {
            var order = _orderBusinessService.Get(1);
            Assert.IsTrue(order.ID == 1);
        }
    }
}