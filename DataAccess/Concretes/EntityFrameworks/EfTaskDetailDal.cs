using DataAccess.Abstracts;
using Entity.Concretes.Models;

namespace DataAccess.Concretes.EntityFrameworks
{
    public class EfTaskDetailDal : EfEntityRepositoryDal<TaskDetail, TaskManagementContext>, ITaskDetailDal
    {
    }
}
