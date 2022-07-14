using DataAccess.Abstracts;
using Entity.Concretes.Models;

namespace DataAccess.Concretes.EntityFrameworks
{
    public class EfCategoryDal : EfEntityRepositoryDal<Category, TaskManagementContext>, ICategoryDal   
    {
    }
}
