using Entity.Concretes.DTO;
using Entity.Concretes.Models;
using System.Linq.Expressions;

namespace Business.Abstracts
{
    public interface IToDoService
    {
        bool Add(ToDo toDo, int fromId);
        bool Update(ToDo toDo);
        bool Delete(int todoId);
        List<ToDo> GetToDos();
        List<ListUserTaskDTO> GetTodosWithUserId(int userId);
    }
}
