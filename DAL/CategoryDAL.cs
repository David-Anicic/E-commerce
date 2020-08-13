using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EP2_2.Data;
using EP2_2.Models;

namespace EP2_2.DAL.Interfaces
{
    public class CategoryDAL : ICategoryDAL
    {
        private readonly ApplicationDbContext _contex;

        public CategoryDAL(ApplicationDbContext contex)
        {
            _contex = contex;
        }

        public void CreateCategory(Category category)
        {
            _contex.Categories.Add(category);
            _contex.SaveChanges();
        }

        public List<Category> GetAllCategories()
        {
            return _contex.Categories.OrderBy(x => x.CategoryName).ToList();

        }

        public Category GetCategoryByID(int categoryID)
        {
            return _contex.Categories.Where(x => x.CategoryID == categoryID).FirstOrDefault();
        }
    }
}
