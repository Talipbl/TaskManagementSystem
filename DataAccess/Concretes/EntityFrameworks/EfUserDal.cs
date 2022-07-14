using DataAccess.Abstracts;
using Entity.Concretes.Models;

namespace DataAccess.Concretes.EntityFrameworks
{
    public class EfUserDal : EfEntityRepositoryDal<User, TaskManagementContext>, IUserDal
    {
    }
}
