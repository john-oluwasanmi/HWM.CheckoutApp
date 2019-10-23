using System;

namespace HWM.CheckoutApp.Interfaces.Entity
{
    public interface IEntity
    {
      
        System.DateTime CreatedOn { get; set; }
        Nullable<System.DateTime> ModifiedOn { get; set; }
        long CreatedBy { get; set; }
        Nullable<long> UpdatedBy { get; set; }
        string CreatedFrom { get; set; }
    }
}
