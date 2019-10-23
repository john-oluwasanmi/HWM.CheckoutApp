using AutoMapper;
using HWM.CheckoutApp.Interfaces.BusinessService;
using HWM.CheckoutApp.Interfaces.DataTransferObject;
using HWM.CheckoutApp.Interfaces.Entity;
using HWM.CheckoutApp.Interfaces.Repository;
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
        protected DTO IDataTransferObject { get; set; } = new DTO();

        public BusinessServiceBase(IRepository<T> repository)
        {
            RepositoryManager = repository;
            IMapper = ConfigureMapper().CreateMapper();
        }

        public void Add(DTO item)
        {
            CheckIfNull(item);
            ValidateId(item.ID);

            if (item.ID > 0)
            {
                throw new Exception("Invalid Id");
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
                throw new Exception($"Invalid {item.GetType().Name} item");
            }
        }

        private void ValidateId(long id)
        {
            if (id < 1)
            {
                throw new Exception($"Invalid {Entity.GetType().Name} Id");
            }
        }

        private MapperConfiguration ConfigureMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DTO, T>();
            });

            return config;
        }
    }
}
