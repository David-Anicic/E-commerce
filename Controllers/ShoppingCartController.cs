using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EP2_2.UI;
using EP2_2.UI.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EP2_2.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartUI _IShoppingCartUI;
        private readonly IProductUI _IProductUI;

        public ShoppingCartController(IShoppingCartUI IShoppingCartUI, IProductUI _IProductUI)
        {
            this._IProductUI = _IProductUI;
            this._IShoppingCartUI = IShoppingCartUI;
        }

        public IActionResult AddToShoppingCart(int productID, int amount=1)
        {
            _IShoppingCartUI.AddToCart(productID, amount);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var ShoppingCartViewModel = new Models.ViewModels.ShoppingCartViewModel();

            ShoppingCartViewModel.ShoppingCartItems = _IShoppingCartUI.GetShoppingCartItems();
            ShoppingCartViewModel.ShoppingCartTotal = _IShoppingCartUI.GetShopingCartTotal();

            return base.View(ShoppingCartViewModel);
        }
        public RedirectToActionResult RemovefromShoppingCart(int productId)
        {
            _IShoppingCartUI.RemovedFromCart(_IProductUI.GetProductDetailsByProductID(productId));
            return RedirectToAction("Index");
        }
    }
    }
