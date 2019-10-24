using HWM.CheckoutApp.EnumType;
using HWM.CheckoutApp.Interfaces.DataTransferObject;
using System;
using System.Collections.Generic;

namespace HWM.CheckoutApp.DTO
{
    public  class ProductDTO : IDataTransferObject
    {
        public long ID => ProductID;

        public long ProductID { get; set; }
        public short ProductCategoryTypeID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public bool IsMultiPriced => DiscountedXItem != null && SpecialPriceForDiscountedXItem != null;

        public Nullable<double> DiscountedXItem { get; set; }
        public Nullable<double> SpecialPriceForDiscountedXItem { get; set; }

        public string ManufactureName { get; set; }
        public double Height { get; set; }
        public double Weigth { get; set; }
        public short? ReorderStockLevel { get; set; }
        public bool IsFragile { get; set; }
        public double Width { get; set; }
        public bool IsRecommended { get; set; }
        public string ImageUrl { get; set; }
        public string ImageName { get; set; }

        public int QuantityInStore => StockItems.Count;

        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long CreatedBy { get; set; }
        public long? UpdatedBy { get; set; }
        public string CreatedFrom { get; set; }

        public virtual List<StockItemDTO> StockItems { get; set; } = new List<StockItemDTO> { };
        public virtual ProductCategoryType ProductCategoryType { get; set; }
    }
}
