using System;
using System.Collections.Generic;

#nullable disable

namespace OOO_Dragocennost.Entity
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
