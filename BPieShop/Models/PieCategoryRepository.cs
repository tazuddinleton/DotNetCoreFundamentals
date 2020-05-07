using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPieShop.Models
{
    public class PieCategoryRepository : IPieCategoryRepository
    {
        List<Category> _categories = new List<Category>();

        public PieCategoryRepository()
        {
            _categories.Add(new Category { CategoryId = 1, CategoryName = "Fruite Pies", Description = "All fruits" });
            _categories.Add(new Category { CategoryId = 2, CategoryName = "Cheese Cakes", Description = "All cheesy" });
            _categories.Add(new Category { CategoryId = 3, CategoryName = "Seasonal Pies", Description = "All seasonal" });
        }
        public IEnumerable<Category> Categories => _categories;

        public Category GetByName(string categoryName)
        {
            return _categories.FirstOrDefault(cat => cat.CategoryName == categoryName);
        }
    }
}
