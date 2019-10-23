using HWM.CheckoutApp.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWM.CheckoutApp.Interfaces.DataTransferObject
{
   public interface IDataTransferObject :IEntity
    {
        long ID { get; }
    }
}
