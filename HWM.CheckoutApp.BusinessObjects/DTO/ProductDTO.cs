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
        public decimal Price { get; set; }

        public bool IsMultiPriced => DiscountedXItem != null && SpecialPriceForXItem != null;

        public Nullable<decimal> DiscountedXItem { get; set; }
        public Nullable<decimal> SpecialPriceForXItem { get; set; }

        public string ManufactureName { get; set; }
        public decimal Height { get; set; }
        public decimal Weigth { get; set; }
        public short? ReorderStockLevel { get; set; }
        public bool IsFragile { get; set; }
        public decimal Width { get; set; }
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
