using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EP2_2.Models;
using EP2_2.Models.ViewModels;
using EP2_2.UI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EP2_2.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICategoryUI _ICategoryUI;
        private readonly IProductUI _IProductUI;

        public AdminController(ICategoryUI category, IProductUI productUI)
        {
            _ICategoryUI = category;
            _IProductUI = productUI;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateCategory(Category category)
        {
            _ICategoryUI.CreateCategory(category);
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateProduct()
        {
            ProductDetailViewModel m = new ProductDetailViewModel();
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var category in _ICategoryUI.GetAllCategories())
            {
                listItems.Add(new SelectListItem { Text = category.CategoryName, Value = category.CategoryID.ToString() });
            }

            m.CategoryNames = listItems;

            return View(m);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateProduct(Product product)
        {
            _IProductUI.CreateProduct(product);
            ProductDetailViewModel m = new ProductDetailViewModel();
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var category in _ICategoryUI.GetAllCategories())
            {
                listItems.Add(new SelectListItem { Text = category.CategoryName, Value = category.CategoryID.ToString() });
            }
            return View(m);
        }
    }
}