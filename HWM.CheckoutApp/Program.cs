using HWM.CheckoutApp.BusinessService;
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
