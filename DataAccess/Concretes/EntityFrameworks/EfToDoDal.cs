using DataAccess.Abstracts;
using Entity.Concretes.Models;

namespace DataAccess.Concretes.EntityFrameworks
{
    public class EfToDoDal : EfEntityRepositoryDal<ToDo, TaskManagementContext>, IToDoDal
    {

    }
}
