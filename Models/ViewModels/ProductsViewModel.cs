using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EP2_2.Models.ViewModels
{
    public class ProductsViewModel
    {

        public long ProductsViewModelID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public bool SearchAllowed { get; set; }
        public string Search { get; set; }
        public PagingInfoViewModel PagingInfoViewModel { get; set; }
        public List<Product> Products { get; set; }
    }
}
