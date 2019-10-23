using HWM.CheckoutApp.Interfaces.DataTransferObject;
using System.Collections.Generic;

namespace HWM.CheckoutApp.Interfaces.BusinessService
{
    public interface IBusinessService<DTO> where DTO : IDataTransferObject
    {
        void Add(DTO item);

        DTO Get(int id);

        List<DTO> List();

        void Update(DTO item);

        void Delete(int id);
        
    }
}
