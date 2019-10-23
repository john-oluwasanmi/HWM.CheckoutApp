using HWM.CheckoutApp.Interfaces.Entity;
using System.Collections.Generic;

namespace HWM.CheckoutApp.Interfaces.Repository
{
    public interface IRepository<T> where T : IEntity
    {
        void Add(T item);

        T Get(int id);

        List<T> List();

        void Update(T item);

        void Delete(int id);
    }
}
