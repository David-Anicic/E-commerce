using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EP2_2.Models
{
    public class Order
    {
        public long OrderID { get; set; }
        public string OrderStatus { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime? OrderShipped { get; set; }
        public bool Paied { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
