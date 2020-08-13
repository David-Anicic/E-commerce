using EP2_2.BL.Interfaces;
using EP2_2.DAL.Interfaces;
using EP2_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EP2_2.BL
{
    public class CategoryBL : ICategoryBL
    {
        private readonly ICategoryDAL _iCategoryDAL;

        public CategoryBL(ICategoryDAL iCategoryDAL)
        {
            _iCategoryDAL = iCategoryDAL;
        }

        public void CreateCategory(Category category)
        {
            _iCategoryDAL.CreateCategory(category);
        }

        public List<Category> GetAllCategories()
        {
            return _iCategoryDAL.GetAllCategories();
        }

        public Category GetCategoryByID(int categoryID)
        {
            return _iCategoryDAL.GetCategoryByID(categoryID);
        }
    }
}
