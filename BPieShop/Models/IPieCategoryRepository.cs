using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPieShop.Models
{
    public interface IPieCategoryRepository
    {
        IEnumerable<Category> Categories { get; }
        Category GetByName(string categoryName);
    }
}
