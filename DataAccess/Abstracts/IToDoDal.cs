using DataAccess.Concretes.EntityFrameworks;
using Entity.Concretes.DTO;
using Entity.Concretes.Models;
using Services.Result.Abstracts;

namespace DataAccess.Abstracts
{
    public interface IToDoDal : IEntityRepositoryDal<ToDo>
    {
        IDataResult<List<ListUserTaskDTO>> GetTodosWithUserId(int userId);
        IDataResult<ToDo> GetLastToDo();
    }
}
