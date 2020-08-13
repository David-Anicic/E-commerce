using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EP2_2.Models
{
    public class ShoppingCartItem
    {
        public long ShoppingCartItemID { get; set; }
        public string ShoppingCartID { get; set; }

        [Range(0,int.MaxValue)]
        public int Amount { get; set; }
        public virtual Product Product { get; set; }

    }
}
