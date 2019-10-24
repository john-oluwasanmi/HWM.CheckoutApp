using System.Collections.Generic;
using HWM.CheckoutApp.EnumType;
using HWM.CheckoutApp.Interfaces.Repository;
using HWM.CheckoutApp.Model;

namespace HWM.CheckoutApp.Repository
{
    public class ProductRepository : RepositoryBase<Product>,
        IProductRepository
    {
        //override the base class methods to your specfication where neccessary
        //and make a call to the base class methods to perform common CRUD functionalities
        //generics is used to factor out common CRUD functionalities


        public override List<Product> List()
        {
            var databaseStore = base.List();

            var products = new List<Product>
           {
               new Product
               {
                   ProductName="A",
                   Price=0.50m,
                   SpecialPriceForXItem =1.30m,
                   DiscountedXItem =3,
                   ProductID =1,
                   ProductCategoryType = ProductCategoryType.Camera
               },

               new Product
               {
                   ProductName="B",
                   Price=0.30m,
                   SpecialPriceForXItem =0.45m,
                   DiscountedXItem =2,
                   ProductID =2,
                   ProductCategoryType = ProductCategoryType.Clothing

               },

               new Product
               {
                   ProductName="C",
                   Price=0.70m,
                   ProductID =3,
                    ProductCategoryType = ProductCategoryType.Food
               },

               new Product
               {
                   ProductName="D",
                   Price=0.20m,
                   ProductID =4,
                     ProductCategoryType = ProductCategoryType.Car
               }
           };

            databaseStore.AddRange(products);

            return databaseStore;
        }
    }
}
