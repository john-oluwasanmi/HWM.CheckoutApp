using HWM.CheckoutApp.BusinessService;
using HWM.CheckoutApp.DTO;
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

            var scannedItem = Console.ReadLine();
            var orderedProducts = scannedItem.Split(',').Select(e => e.TrimEnd().TrimStart().ToUpperInvariant());

            var availableProducts = (from it in orderedProducts
                                     join p in products on it equals p.ProductName
                                     select p).ToList();

            var order = new OrderDTO
            {
                OrderDate = DateTime.Now,
                OrderID = 1
            };

            foreach (var item in availableProducts)
            {
                _orderedProductBusinessService.Add(new OrderedProductDTO
                {
                    Product = item,
                    Order = order
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
