using HWM.CheckoutApp.Interfaces.DataTransferObject;
using System;

namespace HWM.CheckoutApp.Model
{
    public class StockItemDTO : IDataTransferObject
    {
        public long ID => StockItemID;
        public long StockItemID { get; set; }
        public long ProductID { get; set; }
        public int SupplierID { get; set; }


        public string StockRefNumber { get; set; }
        public Nullable<System.DateTime> DateSupplied { get; set; }
        public Nullable<System.DateTime> ExpiringDate { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }



        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public long CreatedBy { get; set; }
        public Nullable<long> UpdatedBy { get; set; }
        public string CreatedFrom { get; set; }

        public virtual Product Product { get; set; }
    }
}
