using Entity.Concretes.Models;
using System.Linq.Expressions;

namespace Business.Abstracts
{
    public interface IToDoService
    {
        bool Add(ToDo toDo);
        bool Update(ToDo toDo);
        bool Delete(int todoId);
        List<ToDo> GetToDos(Expression<Func<ToDo, bool>> filter);
        List<ToDo> GetTodosWithUserId(int userId);
    }
}
