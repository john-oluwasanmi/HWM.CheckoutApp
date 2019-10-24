using HWM.CheckoutApp.BusinessService;
using HWM.CheckoutApp.DTO;
using HWM.CheckoutApp.EnumType;
using HWM.CheckoutApp.Interfaces.BusinessService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWM.CheckoutApp
{
    class Program
    {
        static IOrderBusinessService _orderBusinessService;
        static IOrderedProductBusinessService _orderedProductBusinessService;
        static IProductBusinessService _productBusinessService;
        static IStockItemBusinessService _stockItemBusinessService;

        static void Main(string[] args)
        {
            InitializeApp();

            var products = _productBusinessService.List();

            Console.WriteLine("Scan your selected product by entry a letter separated by comma");
            var scannedItem = Console.ReadLine();
            var orderedProductsScanned = scannedItem.Split(',').Select(e => e.TrimEnd().TrimStart().ToUpperInvariant());

            var availableOrderedProductsInStore = (from it in orderedProductsScanned
                                                   join p in products on it equals p.ProductName
                                                   select p).ToList();

            var orderedProductGroup = from it in availableOrderedProductsInStore
                                      group it by it.ProductName into newGroup
                                      orderby newGroup.Key
                                      select newGroup;



            var order = new OrderDTO
            {
                OrderDate = DateTime.Now,
                OrderID = 1,
                PaymentMethodType = PaymentMethodType.Cash
            };

            foreach (var group in orderedProductGroup)
            {
                var quantity = group.Count();

                _orderedProductBusinessService.Add(new OrderedProductDTO
                {
                    Product = group.FirstOrDefault(),
                    Order = order,
                    OrderID = order.OrderID,
                    ProductID = group.First().ProductID,
                    Quantity = quantity
                });

            }
        }

        private static void InitializeApp()
        {
            AppContainer.RegisterDependencies();

            _orderedProductBusinessService = AppContainer.Resolve<IOrderedProductBusinessService>();
            _productBusinessService = AppContainer.Resolve<IProductBusinessService>();
            _stockItemBusinessService = AppContainer.Resolve<IStockItemBusinessService>();
            _orderBusinessService = AppContainer.Resolve<IOrderBusinessService>();

        }
    }
}
