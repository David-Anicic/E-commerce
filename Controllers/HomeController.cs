using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EP2_2.Models;
using EP2_2.Models.ViewModels;
using EP2_2.UI.Interfaces;
using EP2_2.UI;

namespace EP2_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductUI _iProductUI;

        public HomeController(IProductUI iProductUI)
        {
            _iProductUI = iProductUI;
        }

        public IActionResult Index()
        {
            ProductsViewModel p = new ProductsViewModel();
            p.Products = _iProductUI.GetAllProducts().Take(6).ToList();
            p.Title = "Product from database";
            p.SubTitle = "There is six products from database!";

            ProductsViewModel p1 = new ProductsViewModel();
            p1.Products = _iProductUI.PreferredProducts().Take(6).ToList();
            p1.Title = "Preferred products";
            p1.SubTitle = "There is six preferred products from database";

            ProductsViewModel p2 = new ProductsViewModel();
            p2.Products = _iProductUI.NewestProducts().Take(6).ToList();
            p2.Title = "Newset products";
            p2.SubTitle = "There is six newest products from database";

            ProductsViewModel p3 = new ProductsViewModel();
            p3.Products = _iProductUI.BestBuyProducts().Take(6).ToList();
            p3.Title = "Best Buy products";
            p3.SubTitle = "There is six best buy products from database";

            return View(new List<ProductsViewModel>() { p, p1, p2, p3 });
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
