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
        ITaskDetailService _taskDetailService;
        public ToDoManager(IToDoDal toDoDal, ITaskDetailService taskDetailService)
        {
            _toDoDal = toDoDal;
            _taskDetailService = taskDetailService;
        }

        public bool Add(ToDo toDo, int fromId)
        {
            if (_toDoDal.Add(toDo))
            {
                var lastToDo = _toDoDal.GetLastToDo();
                TaskDetail taskDetail = new TaskDetail()
                {
                    TaskId = lastToDo.TaskId,
                    FromId = fromId,
                    OpenDate = DateTime.Now,
                    Status = false
                };
                return _taskDetailService.Add(taskDetail);
            }
            return false;
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
