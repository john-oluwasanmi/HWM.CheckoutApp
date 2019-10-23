using HWM.CheckoutApp.EnumType;
using HWM.CheckoutApp.Interfaces.Entity;
using System;
using System.Collections.Generic;

namespace HWM.CheckoutApp.Model
{
    public class Order : IEntity
    {
        public long ID => OrderID;
        public int OrderID { get; set; }
        public byte PaymentMethodTypeID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public decimal TotalAmountPaid { get; set; }



        public decimal? Discount { get; set; }
        public int PaymentTransactionNumber { get; set; }
        public string OrderTrackingNumber { get; set; }
        public decimal? VATCharge { get; set; }
        public decimal TotalCost { get; set; }
        public System.DateTime PaymentTransactionDate { get; set; }

        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public long CreatedBy { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public string CreatedFrom { get; set; }

        public virtual PaymentMethodType PaymentMethodType { get; set; }

        public virtual ICollection<OrderedProduct> OrderedProducts { get; set; }

    }
}
