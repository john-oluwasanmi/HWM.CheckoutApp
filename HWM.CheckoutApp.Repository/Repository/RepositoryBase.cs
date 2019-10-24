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
            // call to REST api 

            throw new NotImplementedException();
        }
        public virtual T Get(int id)
        {
            // call to REST api 
            throw new NotImplementedException();
        }
        public virtual List<T> List()
        {
            // call to REST api 
            throw new NotImplementedException();
        }
        public virtual void Update(T item)
        {
            // call to REST api 
            throw new NotImplementedException();
        }
        public virtual void Delete(int id)
        {
            // call to REST api 
            throw new NotImplementedException();
        }
    }
}

