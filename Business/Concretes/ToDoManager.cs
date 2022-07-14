using Business.Abstracts;
using DataAccess.Abstracts;
using Entity.Concretes.DTO;
using Entity.Concretes.Models;
using System.Linq.Expressions;

namespace Business.Concretes
{
    public class ToDoManager : IToDoService
    {
        IToDoDal _toDoDal;
        public ToDoManager(IToDoDal toDoDal)
        {
            _toDoDal = toDoDal;
        }

        public bool Add(ToDo toDo)
        {
            return _toDoDal.Add(toDo);
        }

        public bool Delete(int todoId)
        {
            return _toDoDal.Delete(new ToDo { TaskId = todoId });
        }

        public List<ToDo> GetToDos()
        {
            return _toDoDal.GetAll();
        }

        public List<ListUserTaskDTO> GetTodosWithUserId(int userId)
        {
            return _toDoDal.GetTodosWithUserId(userId);
        }

        public bool Update(ToDo toDo)
        {
            return _toDoDal.Update(toDo);
        }
    }
}
