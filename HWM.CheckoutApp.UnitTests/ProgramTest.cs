using HWM.CheckoutApp.EnumType;
using HWM.CheckoutApp.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HWM.CheckoutApp.UnitTests
{
    [TestClass]
    public class ProgramTest
    {
        List<Product> _products;

        [TestInitialize]
        public void Setup()
        {
            _products = new List<Product>
           {
               new Product
               {
                   ProductName="A",
                   Price=0.50d,
                   SpecialPriceForDiscountedXItem =1.30d,
                   DiscountedXItem =3,
                   ProductID =1,
                   ProductCategoryType = ProductCategoryType.Camera
               },

               new Product
               {
                   ProductName="B",
                   Price=0.30d,
                   SpecialPriceForDiscountedXItem =0.45d,
                   DiscountedXItem =2,
                   ProductID =2,
                   ProductCategoryType = ProductCategoryType.Clothing

               },

               new Product
               {
                   ProductName="C",
                   Price=0.70d,
                   ProductID =3,
                    ProductCategoryType = ProductCategoryType.Food
               },

               new Product
               {
                   ProductName="D",
                   Price=0.20d,
                   ProductID =4,
                     ProductCategoryType = ProductCategoryType.Car
               }
           };
        }
        public void ScanItemsTest()
        {
            //Todo- test all the public methods in Program class if there is more time
        }

        public void CheckForAvailabilityTest()
        {
            //Todo- test all the public methods in Program class if there is more time
        }
    }
}
