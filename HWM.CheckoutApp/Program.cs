using HWM.CheckoutApp.DTO;
using HWM.CheckoutApp.EnumType;
using HWM.CheckoutApp.Interfaces.BusinessService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HWM.CheckoutApp
{
    public class Program
    {
        static IOrderBusinessService _orderBusinessService;
        static IOrderedProductBusinessService _orderedProductBusinessService;
        static IProductBusinessService _productBusinessService;
        static IStockItemBusinessService _stockItemBusinessService;

        static void Main(string[] args)
        {
            InitializeApp();

            var products = _productBusinessService.List();

            IntroductionMessage();

            while (Console.ReadKey().Key != ConsoleKey.End)
            {
                Console.WriteLine();
                Console.WriteLine();

                List<ProductDTO> availableScannedProductsInStore = ScanItemsAndCheckForAvailability(products);

                var scannedProductGroup = from it in availableScannedProductsInStore
                                          group it by it.ProductName into newGroup
                                          orderby newGroup.Key
                                          select newGroup;

                AddToBasket(scannedProductGroup);

                var orderedProducts = _orderedProductBusinessService.List();

                CalculateTotalCost(orderedProducts);
            }

            Console.WriteLine("Exiting.... ");
            Console.ReadLine();
        }

        private static void IntroductionMessage()
        {
            Console.WriteLine("Press any key to start new order and End key to exit.... ");
            Console.WriteLine();
        }

        private static OrderDTO CreateOrder()
        {
            var order = new OrderDTO
            {
                OrderDate = DateTime.Now,
                PaymentMethodType = PaymentMethodType.Cash
            };

            _orderBusinessService.Add(order);


            return _orderBusinessService.List().Last(); // it is assumed the last order saved is the current order, ideal it should be fetch from the database by Id
        }

        private static void AddToBasket(IOrderedEnumerable<IGrouping<string, ProductDTO>> scannedProductGroup)
        {
            var order = CreateOrder();

            foreach (var group in scannedProductGroup)
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

        private static List<ProductDTO> ScanItemsAndCheckForAvailability(List<ProductDTO> products)
        {
            Console.WriteLine("Scan your selected product by entry a letter separated by comma");
            Console.WriteLine();

            var scannedItem = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();

            var orderedProductsScanned = scannedItem.Split(',').Select(e => e.TrimEnd().TrimStart().ToUpperInvariant());

            var availableOrderedProductsInStore = (from it in orderedProductsScanned
                                                   join p in products on it equals p.ProductName
                                                   select p).ToList();
            return availableOrderedProductsInStore;
        }

        private static void CalculateTotalCost(List<OrderedProductDTO> orderedProducts)
        {
            double totalPrice = 0;

            foreach (var item in orderedProducts)
            {
                if (item.Product.IsMultiPriced)
                {
                    var extra = item.Quantity % item.Product.DiscountedXItem;
                    var extraCost = extra * item.Product.Price;

                    int discountedSelections = Convert.ToInt32(Math.Floor(item.Quantity / (double)item.Product.DiscountedXItem));
                    var dicountedPrice = discountedSelections * (double)item.Product.SpecialPriceForDiscountedXItem;

                    totalPrice += dicountedPrice + extraCost ?? 0;
                    
                    Console.WriteLine($"{item.Quantity} items of {item.Product.ProductName} was scanned at special offer {item.Product.DiscountedXItem} for £{item.Product.SpecialPriceForDiscountedXItem} and one {item.Product.ProductName}  costs  £{item.Product.Price}");
                    Console.WriteLine();
                    Console.WriteLine($"{discountedSelections * item.Product.DiscountedXItem} items are within special offer in mutiple of {item.Product.DiscountedXItem} while {extra} are the extras");
                    Console.WriteLine();
                    Console.WriteLine($"Discounted Price : £{dicountedPrice}   while £{extraCost} is the cost of extras making total of £{dicountedPrice + extraCost ?? 0}");
                    Console.WriteLine();
                    Console.WriteLine();

                    continue;
                }

                var nonDiscountedPrice = item.Product.Price * item.Quantity;

                Console.WriteLine($"{item.Quantity} of {item.Product.ProductName} scanned at £{item.Product.Price} making total of £{nonDiscountedPrice} with no sepcial offers");

                totalPrice += nonDiscountedPrice;
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine($"Total Price Paid: £{totalPrice} ");
            Console.WriteLine();

            IntroductionMessage();
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
