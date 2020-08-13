using EP2_2.UI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EP2_2.Components
{
    public class CategoryMenu : ViewComponent
    {
        private ICategoryUI categoryUI;
        public CategoryMenu(ICategoryUI _categoryUI)
        {
            categoryUI = _categoryUI;
        }
        public IViewComponentResult Invoke()
        {
            var categories = categoryUI.GetAllCategories();
            return View(categories);
        }
    }
}
