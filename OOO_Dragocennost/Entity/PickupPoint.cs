using System;
using System.Collections.Generic;

#nullable disable

namespace OOO_Dragocennost.Entity
{
    public partial class PickupPoint
    {
        public PickupPoint()
        {
            Orders = new HashSet<Order>();
        }

        public int PickupPointId { get; set; }
        public int PickupPointIndex { get; set; }
        public string PickupPointCity { get; set; }
        public string PickupPointStreet { get; set; }
        public int PickupPointHouse { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
