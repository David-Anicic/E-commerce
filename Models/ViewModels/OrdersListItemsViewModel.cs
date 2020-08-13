using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EP2_2.Models.ViewModels
{
    public class OrdersListItemsViewModel
    {
        public int OrdersListItemsViewModelID { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public decimal Total { get; set; }

    }
}
