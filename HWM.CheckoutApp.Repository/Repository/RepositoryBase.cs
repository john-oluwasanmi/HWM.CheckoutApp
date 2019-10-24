using HWM.CheckoutApp.Interfaces.Entity;
using HWM.CheckoutApp.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HWM.CheckoutApp.Repository
{
    public class RepositoryBase<T> : IRepository<T>
      where T : IEntity, new()
    {
        protected T Entity { get; set; } = new T();
        public List<T> DatabaseEntitySimulation;

        public RepositoryBase()
        {
            DatabaseEntitySimulation = new List<T>();
        }
        public void Add(T item)
        {
            // Ideally a call to REST api 
            //but using memory as data store

            DatabaseEntitySimulation.Add(item);
        }
        public virtual T Get(int id)
        {
            // call to REST api 
            throw new NotImplementedException();
        }
        public virtual List<T> List()
        {
            // Ideally a call to REST api 
            //but using memory as data store

            return DatabaseEntitySimulation;
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

