using Autofac;
using HWM.CheckoutApp.BusinessService;
using HWM.CheckoutApp.DTO;
using HWM.CheckoutApp.Interfaces.BusinessService;
using HWM.CheckoutApp.Interfaces.Repository;
using HWM.CheckoutApp.Model;
using HWM.CheckoutApp.Repository;
using System;

namespace HWM.CheckoutApp
{
    public class AppContainer
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //DTO
            builder.RegisterType<OrderDTO>();
            builder.RegisterType<OrderedProductDTO>();
            builder.RegisterType<ProductDTO>();
            builder.RegisterType<StockItemDTO>();

            //Models
            builder.RegisterType<Order>();
            builder.RegisterType<OrderedProduct>();
            builder.RegisterType<Product>();
            builder.RegisterType<StockItem>();

            //business service
            builder.RegisterType<OrderBusinessService>().As<IOrderBusinessService>().SingleInstance();
            builder.RegisterType<OrderedProductBusinessService>().As<IOrderedProductBusinessService>().SingleInstance();
            builder.RegisterType<ProductBusinessService>().As<IProductBusinessService>().SingleInstance();
            builder.RegisterType<StockItemBusinessService>().As<IStockItemBusinessService>().SingleInstance();

            //repository
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().SingleInstance();
            builder.RegisterType<OrderedProductRepository>().As<IOrderedProductRepository>().SingleInstance();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().SingleInstance();
            builder.RegisterType<StockItemRepository>().As<IStockItemRepository>().SingleInstance();

            builder.RegisterGeneric(typeof(BusinessServiceBase<,>))
               .As(typeof(IBusinessService<>))
               .InstancePerDependency();

            builder.RegisterGeneric(typeof(RepositoryBase<>))
              .As(typeof(IRepository<>))
              .InstancePerDependency();


            _container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
