using HWM.CheckoutApp.Interfaces.Entity;
using HWM.CheckoutApp.Interfaces.Repository;
using System;
using System.Collections.Generic;

namespace HWM.CheckoutApp.Repository
{
    public class RepositoryBase<T> : IRepository<T>
      where T : IEntity
    {
        public void Add(T item)
        {
            throw new NotImplementedException();
        }
        public virtual T Get(int id)
        {
            throw new NotImplementedException();
        }
        public virtual List<T> List()
        {
            throw new NotImplementedException();
        }
        public virtual void Update(T item)
        {
            throw new NotImplementedException();
        }
        public virtual void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

