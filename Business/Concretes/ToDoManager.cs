using Business.Abstracts;
using DataAccess.Abstracts;
using Entity.Concretes.DTO;
using Entity.Concretes.Models;
using Services.Constants;
using Services.Result;
using Services.Result.Abstracts;
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

        public IResult Add(ToDo toDo, int fromId)
        {
            if (_toDoDal.Add(toDo))
            {
                var lastToDo = _toDoDal.GetLastToDo().Data;
                TaskDetail taskDetail = new TaskDetail()
                {
                    TaskId = lastToDo.TaskId,
                    FromId = fromId,
                    OpenDate = DateTime.Now,
                    Status = false
                };
                return _taskDetailService.Add(taskDetail);
            }
            return new ErrorResult(MessageHelper.CreateMessage(Messages.Task,Messages.InsertError));
        }

        public IResult Delete(int todoId)
        {
            if (_toDoDal.Delete(new ToDo { TaskId = todoId }))
            {
                return new SuccessResult(MessageHelper.CreateMessage(Messages.Task, Messages.Deleted));
            }
            return new ErrorResult(MessageHelper.CreateMessage(Messages.Task, Messages.DeletionError));
        }

        public IDataResult<List<ToDo>> GetToDos()
        {
            return new SuccessDataResult<List<ToDo>>(_toDoDal.GetAll());
        }

        public IDataResult<List<ListUserTaskDTO>> GetTodosWithUserId(int userId)
        {
            return _toDoDal.GetTodosWithUserId(userId);
        }

        public IResult Update(ToDo toDo)
        {
            if (_toDoDal.Update(toDo))
            {
                return new SuccessResult(MessageHelper.CreateMessage(Messages.Task, Messages.Updated));
            }
            return new ErrorResult(MessageHelper.CreateMessage(Messages.Task, Messages.UpdateError));
        }
    }
}
