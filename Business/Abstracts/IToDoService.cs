using Entity.Concretes.DTO;
using Entity.Concretes.Models;
using Services.Result.Abstracts;
using System.Linq.Expressions;

namespace Business.Abstracts
{
    public interface IToDoService
    {
        IResult Add(ToDo toDo, int fromId);
        IResult Update(ToDo toDo);
        IResult Delete(int todoId);
        IDataResult<List<ToDo>> GetToDos();
        IDataResult<List<ListUserTaskDTO>> GetTodosWithUserId(int userId);
    }
}
