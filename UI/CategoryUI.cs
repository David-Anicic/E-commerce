using EP2_2.BL.Interfaces;
using EP2_2.Models;
using EP2_2.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EP2_2.UI
{
    public class CategoryUI : ICategoryUI
    {

        private readonly ICategoryBL _iCategoryBL;

        public CategoryUI(ICategoryBL iCategoryBL)
        {
            _iCategoryBL = iCategoryBL;
        }

        public void CreateCategory(Category category)
        {
            _iCategoryBL.CreateCategory(category);
        }

        public List<Category> GetAllCategories()
        {
            return _iCategoryBL.GetAllCategories();
        }

        public Category GetCategoryByID(int categoryID)
        {
            return _iCategoryBL.GetCategoryByID(categoryID);
        }
    }
}
