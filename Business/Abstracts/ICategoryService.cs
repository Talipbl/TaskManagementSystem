using Entity.Concretes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICategoryService
    {
        bool Add(Category category);
        bool Update(Category category);
        bool Delete(int categoryId);
        List<Category> GetCategories();
        Category GetCategory(int categoryId);
    }
}
