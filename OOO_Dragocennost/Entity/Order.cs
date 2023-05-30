using System;
using System.Collections.Generic;

#nullable disable

namespace OOO_Dragocennost.Entity
{
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int OrderId { get; set; }
        public DateTime? OrderOrderDate { get; set; }
        public DateTime? OrderDeliveryDate { get; set; }
        public int OrderPickupPoint { get; set; }
        public int? OrderUser { get; set; }
        public int OrderCode { get; set; }
        public string OrderStatus { get; set; }

        public virtual PickupPoint OrderPickupPointNavigation { get; set; }
        public virtual User OrderUserNavigation { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
