using EP2_2.Models.ViewModels;
using EP2_2.UI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EP2_2.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IShoppingCartUI _IShoppingCartUI;

        public ShoppingCartSummary(IShoppingCartUI IShoppingCartUI)
        {
            _IShoppingCartUI = IShoppingCartUI;
        }
        public IViewComponentResult Invoke()
        {
            ShoppingCartViewModel shopingCartViewModel = new ShoppingCartViewModel();

            shopingCartViewModel.ShoppingCartTotal = _IShoppingCartUI.GetShopingCartTotal();
            shopingCartViewModel.ShoppingCartItems = _IShoppingCartUI.GetShoppingCartItems();
            return View(shopingCartViewModel);
        }
    }
}
