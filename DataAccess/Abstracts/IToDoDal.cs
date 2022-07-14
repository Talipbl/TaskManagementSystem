using DataAccess.Concretes.EntityFrameworks;
using Entity.Concretes.DTO;
using Entity.Concretes.Models;

namespace DataAccess.Abstracts
{
    public interface IToDoDal : IEntityRepositoryDal<ToDo>
    {
        List<ListUserTaskDTO> GetTodosWithUserId(int userId);
    }
}
