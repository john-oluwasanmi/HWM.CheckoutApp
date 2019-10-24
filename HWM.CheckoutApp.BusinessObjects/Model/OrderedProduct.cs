using HWM.CheckoutApp.Interfaces.Entity;
using System;

namespace HWM.CheckoutApp.Model
{
    public class OrderedProduct : IEntity
    {
        public long OrderProductID { get; set; }
        public long OrderID { get; set; }
        public long ProductID { get; set; }

        public short Quantity { get; set; }

        public Nullable<decimal> Discount { get; set; }

        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public long CreatedBy { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public string CreatedFrom { get; set; }


        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
