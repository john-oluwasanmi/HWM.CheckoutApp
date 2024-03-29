﻿using HWM.CheckoutApp.EnumType;
using HWM.CheckoutApp.Interfaces.DataTransferObject;
using System;
using System.Collections.Generic;

namespace HWM.CheckoutApp.DTO
{
    public class OrderDTO : IDataTransferObject
    {
        public long ID => OrderID;
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public byte PaymentMethodTypeID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public double TotalAmountPaid { get; set; }



        public double? Discount { get; set; }
        public int PaymentTransactionNumber { get; set; }
        public string OrderTrackingNumber { get; set; }
        public double? VATCharge { get; set; }
        public double TotalCost { get; set; }
        public System.DateTime PaymentTransactionDate { get; set; }

        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public long CreatedBy { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public string CreatedFrom { get; set; }

        public virtual PaymentMethodType PaymentMethodType { get; set; }

        public virtual ICollection<OrderedProductDTO> OrderedProducts { get; set; }

    }
}
