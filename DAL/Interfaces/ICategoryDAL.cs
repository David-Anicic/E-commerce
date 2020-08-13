using EP2_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EP2_2.DAL.Interfaces
{
    public interface ICategoryDAL
    {
        Category GetCategoryByID(int categoryID);
        List<Category> GetAllCategories();
        void CreateCategory(Category category);
    }
}
