﻿using AutoMapper;
using HWM.CheckoutApp.DTO;
using HWM.CheckoutApp.Interfaces.BusinessService;
using HWM.CheckoutApp.Interfaces.DataTransferObject;
using HWM.CheckoutApp.Interfaces.Entity;
using HWM.CheckoutApp.Interfaces.Repository;
using HWM.CheckoutApp.Model;
using System;
using System.Collections.Generic;

namespace HWM.CheckoutApp.BusinessService
{
    public class BusinessServiceBase<DTO, T> : IBusinessService<DTO>
        where DTO : IDataTransferObject, new()
        where T : IEntity, new()
    {
        protected readonly IRepository<T> RepositoryManager;
        protected readonly IMapper IMapper;

        protected T Entity { get; set; } = new T();
        protected DTO DataTransferObject { get; set; } = new DTO();

        public BusinessServiceBase(IRepository<T> repository)
        {
            RepositoryManager = repository;
            IMapper = ConfigureMapper().CreateMapper();
        }

        public virtual void Add(DTO item)
        {
            CheckIfNull(item);

            if (item.ID > 0)
            {
                var typeName = Entity.GetType().Name;
                throw new Exception($"Invalid {typeName}Id");
            }

            var result = IMapper.Map<DTO, T>(item);
            RepositoryManager.Add(result);
        }
        public virtual DTO Get(int id)
        {
            ValidateId(id);
            var entity = RepositoryManager.Get(id);
            var result = IMapper.Map<T, DTO>(entity);

            return result;
        }

        public virtual List<DTO> List()
        {
            var entities = RepositoryManager.List();
            var result = IMapper.Map<List<T>, List<DTO>>(entities);

            return result;
        }

        public virtual void Update(DTO item)
        {
            CheckIfNull(item);
            ValidateId(item.ID);

            var result = IMapper.Map<DTO, T>(item);

            RepositoryManager.Update(result);
        }

        public virtual void Delete(int id)
        {
            ValidateId(id);
            RepositoryManager.Delete(id); ;
        }

        private void CheckIfNull(DTO item)
        {
            if (item == null)
            {
                var typeName = Entity.GetType().Name;
                throw new NullReferenceException($"Invalid {typeName} item");
            }
        }

        private void ValidateId(long id)
        {
            if (id < 1)
            {
                throw new Exception($"Invalid {Entity.GetType().Name}Id");
            }
        }

        private MapperConfiguration ConfigureMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DTO, T>();
                cfg.CreateMap<T, DTO>();

                cfg.CreateMap<OrderDTO, Order>();
                cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<OrderedProductDTO, OrderedProduct>();
                cfg.CreateMap<StockItemDTO, StockItem>();

                cfg.CreateMap<Order, OrderDTO>();
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<OrderedProduct, OrderedProductDTO>();
                cfg.CreateMap<StockItem, StockItemDTO>();
            });

            return config;
        }
    }
}
