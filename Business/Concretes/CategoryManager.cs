using Business.Abstracts;
using DataAccess.Abstracts;
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
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public bool Add(Category category)
        {
            return _categoryDal.Add(category);
        }

        public bool Delete(int categoryId)
        {
            return _categoryDal.Delete(new Category { CategoryId = categoryId});
        }

        public List<Category> GetCategories()
        {
            return _categoryDal.GetAll();
        }

        public Category GetCategory(int categoryId)
        {
            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }

        public bool Update(Category category)
        {
            return _categoryDal.Update(category);
        }
    }
}
