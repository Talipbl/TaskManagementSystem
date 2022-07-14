using Business.Abstracts;
using Entity.Concretes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        public bool Add(Category category)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int categoryId)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public bool Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
