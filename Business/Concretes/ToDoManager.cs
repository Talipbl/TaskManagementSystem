using Business.Abstracts;
using Entity.Concretes.Models;
using System.Linq.Expressions;

namespace Business.Concretes
{
    public class ToDoManager : IToDoService
    {
        public bool Add(ToDo toDo)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int todoId)
        {
            throw new NotImplementedException();
        }

        public List<ToDo> GetToDos(Expression<Func<ToDo, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ToDo> GetTodosWithUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public bool Update(ToDo toDo)
        {
            throw new NotImplementedException();
        }
    }
}
