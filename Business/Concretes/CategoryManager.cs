using Business.Abstracts;
using DataAccess.Abstracts;
using Entity.Concretes.Models;
using Services.Constants;
using Services.Result;
using Services.Result.Abstracts;
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

        public IResult Add(Category category)
        {
            if (_categoryDal.Add(category))
            {
                return new SuccessResult(MessageHelper.CreateMessage(Messages.Category, Messages.Added));
            }
            return new ErrorResult(MessageHelper.CreateMessage(Messages.Category, Messages.InsertError));
        }

        public IResult Delete(int categoryId)
        {
            if (_categoryDal.Delete(new Category { CategoryId = categoryId }))
            {
                return new SuccessResult(MessageHelper.CreateMessage(Messages.Category, Messages.Deleted));
            }
            return new ErrorResult(MessageHelper.CreateMessage(Messages.Category, Messages.DeletionError));

        }

        public IDataResult<List<Category>> GetCategories()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetCategory(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == categoryId));
        }

        public IResult Update(Category category)
        {
            if (_categoryDal.Update(category))
            {
                return new SuccessResult(MessageHelper.CreateMessage(Messages.Category, Messages.Updated));
            }
            return new ErrorResult(MessageHelper.CreateMessage(Messages.Category, Messages.UpdateError));
        }
    }
}
