using Entity.Concretes.Models;
using Services.Result.Abstracts;
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
        IResult Add(Category category);
        IResult Update(Category category);
        IResult Delete(int categoryId);
        IDataResult<List<Category>> GetCategories();
        IDataResult<Category> GetCategory(int categoryId);
    }
}
