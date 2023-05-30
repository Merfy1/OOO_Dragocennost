using System;
using System.Collections.Generic;

#nullable disable

namespace OOO_Dragocennost.Entity
{
    public partial class Product
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public string ProductArticleNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductUnit { get; set; }
        public decimal ProductCost { get; set; }
        public byte ProductMaxDiscount { get; set; }
        public int ProductManufacturer { get; set; }
        public int ProductSupplier { get; set; }
        public int ProductCategory { get; set; }
        public byte? ProductDiscountAmount { get; set; }
        public int ProductQuantityInStock { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public string ProductStatus { get; set; }

        public virtual Category ProductCategoryNavigation { get; set; }
        public virtual Manufacturer ProductManufacturerNavigation { get; set; }
        public virtual Supplier ProductSupplierNavigation { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public string DisplayImage { get
            {
                return $"pack://application:,,,/Resources/{ProductImage}";
            } }
    }
}
