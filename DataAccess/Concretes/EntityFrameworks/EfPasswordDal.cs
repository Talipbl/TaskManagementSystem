using DataAccess.Abstracts;
using Entity.Concretes.Models;

namespace DataAccess.Concretes.EntityFrameworks
{
    public class EfPasswordDal : EfEntityRepositoryDal<Password, TaskManagementContext>, IPasswordDal
    {
    }
}
