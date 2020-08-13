using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EP2_2.Models.ViewModels;
using EP2_2.UI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EP2_2.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductUI _iProductUI;
        private readonly ICategoryUI _iCategoryUI;
        private const int PageSize = 9;

        public ProductController(IProductUI iProductUI,ICategoryUI iCategoryUI )
        {
            _iProductUI = iProductUI;
            _iCategoryUI = iCategoryUI;
        }
        public IActionResult Index(string search="", int page=1)
        {
            var products = _iProductUI.GetAllProducts();
            ProductsViewModel p = new ProductsViewModel();
            p.Title = "All products";
            p.SubTitle ="There is all products from database";
            if (!string.IsNullOrEmpty(search))
            {
                products = _iProductUI.SearchProducts(products, search);
            }

            p.SearchAllowed = true;
            p.Products = products.Skip((page - 1) * PageSize).Take(PageSize).ToList();
            p.PagingInfoViewModel = new PagingInfoViewModel { CurrentPage = page, ItemPerPage = PageSize, TotalItems = products.Count() };
            return View(new List<ProductsViewModel>() { p });
        }

        [Route("/Product/Details",Name = "routeDetails")]
        public IActionResult Details(int productID)
        {
            ProductDetailViewModel p = new ProductDetailViewModel();
            var product = _iProductUI.GetProductDetailsByProductID(productID);
            p.ProductID = product.ProductID;
            p.CategoryID = product.CategoryID;
            p.CategoryName = product.Category.CategoryName;
            p.DateCreate = product.DateCreate;
            p.ImageUrl = product.ImageUrl;
            p.InStock = product.InStock;
            p.IsPrefered = product.IsPrefered;
            p.LongDescription = product.LongDescription;
            p.Name = product.Name;
            p.NumberOfOrders = product.NumberOfOrders;
            p.Price = product.Price;
            p.ShortDescription = product.ShortDescription;
            return View(p);
        }
        public IActionResult PreferredProducts(string search="",int page=1)
        {
            ProductsViewModel p = new ProductsViewModel();
            p.Title = "Preferred products";
            p.SubTitle = "There is all preferred products";
            var products = _iProductUI.PreferredProducts();
            if(!string.IsNullOrEmpty(search))
            {
                products = _iProductUI.SearchProducts(products, search);
            }

            p.SearchAllowed = true;
            p.Products = products.Skip((page - 1) * PageSize).Take(PageSize).ToList();
            p.PagingInfoViewModel = new PagingInfoViewModel { CurrentPage = page, ItemPerPage = PageSize, TotalItems = products.Count() };
            return View("Index", new List<ProductsViewModel>() { p });
        }

        public IActionResult BestBuyProducts(string search="", int page=1)
        {
            var products = _iProductUI.BestBuyProducts();
            ProductsViewModel p = new ProductsViewModel();
            p.Products = products;
            p.Title = "Best buy products";
            p.SubTitle = "Ordered by number of orders";
            p.SearchAllowed = true;
            if (!string.IsNullOrEmpty(search))
            {
                products = _iProductUI.SearchProducts(products, search);
            }
            p.Products = products.Skip((page - 1) * PageSize).Take(PageSize).ToList();
            p.PagingInfoViewModel = new PagingInfoViewModel { CurrentPage = page, ItemPerPage = PageSize, TotalItems = products.Count() };
            return View("Index", new List<ProductsViewModel>() { p });
        }

        public IActionResult NewestProducts(string search = "", int page=1)
        {
            var products = _iProductUI.NewestProducts();
            ProductsViewModel p = new ProductsViewModel();
            p.Title = "Newst products";
            p.SubTitle = "Ordered by data created";
            p.SearchAllowed = true;
            if (!string.IsNullOrEmpty(search))
            {
                products = _iProductUI.SearchProducts(products, search);
            }
            p.Products = products.Skip((page - 1) * PageSize).Take(PageSize).ToList();
            p.PagingInfoViewModel = new PagingInfoViewModel { CurrentPage = page, ItemPerPage = PageSize, TotalItems = products.Count() };
            return View("Index", new List<ProductsViewModel>() { p });
        }

        public IActionResult GetProductByCategory(int categoryID,string search = "", int page=1)
        {
                var products = _iProductUI.GetProductsByCategory(categoryID);
                var category = _iCategoryUI.GetCategoryByID(categoryID);
                ProductsViewModel p = new ProductsViewModel();
                p.Title = category.CategoryName;
                p.SubTitle = "All products by " + category.CategoryName + " categoru";
                p.SearchAllowed = true;
                if (!string.IsNullOrEmpty(search))
                {
                    products = _iProductUI.SearchProducts(products, search);
                }
               
                p.Products = products.Skip((page - 1) * PageSize).Take(PageSize).ToList();
                p.PagingInfoViewModel = new PagingInfoViewModel { CurrentPage = page, ItemPerPage = PageSize, TotalItems = products.Count() };
                return View("Index", new List<ProductsViewModel>() { p });
        }

    }
}