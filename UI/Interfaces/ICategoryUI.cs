using EP2_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EP2_2.UI.Interfaces
{
    public interface ICategoryUI
    {
        Category GetCategoryByID(int categoryID);
        List<Category> GetAllCategories();
        void CreateCategory(Category category);
    }
}
