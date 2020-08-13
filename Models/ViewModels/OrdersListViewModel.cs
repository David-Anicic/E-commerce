using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EP2_2.Models.ViewModels
{
    public class OrdersListViewModel
    {
        int OrdersListViewModelID { get; set; }
        public List<Order> Orders { get; set; }
    }
}
