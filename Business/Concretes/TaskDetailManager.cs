using Business.Abstracts;
using DataAccess.Abstracts;
using Entity.Concretes.Models;
using Services.Constants;
using Services.Result;
using Services.Result.Abstracts;

namespace Business.Concretes
{
    public class TaskDetailManager : ITaskDetailService
    {
        ITaskDetailDal _taskDetailDal;
        public TaskDetailManager(ITaskDetailDal taskDetailDal)
        {
            _taskDetailDal = taskDetailDal;
        }

        public IResult Add(TaskDetail taskDetail)
        {
            if (_taskDetailDal.Add(taskDetail))
            {
                return new SuccessResult(MessageHelper.CreateMessage(Messages.TaskDetail, Messages.Added));
            }
            return new ErrorResult(MessageHelper.CreateMessage(Messages.TaskDetail, Messages.InsertError));
        }

        public IResult Delete(int taskId)
        {
            if (_taskDetailDal.Delete(new TaskDetail { TaskId = taskId }))
            {
                return new SuccessResult(MessageHelper.CreateMessage(Messages.TaskDetail, Messages.Deleted));
            }
            return new ErrorResult(MessageHelper.CreateMessage(Messages.TaskDetail, Messages.DeletionError));
        }

        public IDataResult<TaskDetail> GetTaskDetail(int taskId)
        {
            return new SuccessDataResult<TaskDetail>(_taskDetailDal.Get(t => t.TaskId == taskId));
        }

        public IResult Update(TaskDetail taskDetail)
        {
            if (_taskDetailDal.Update(taskDetail))
            {
                return new SuccessResult(MessageHelper.CreateMessage(Messages.TaskDetail, Messages.Updated));
            }
            return new ErrorResult(MessageHelper.CreateMessage(Messages.TaskDetail, Messages.UpdateError));

        }
    }
}
