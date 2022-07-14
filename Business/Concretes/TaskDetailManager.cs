using Business.Abstracts;
using DataAccess.Abstracts;
using Entity.Concretes.Models;

namespace Business.Concretes
{
    public class TaskDetailManager : ITaskDetailService
    {
        ITaskDetailDal _taskDetailDal;
        public TaskDetailManager(ITaskDetailDal taskDetailDal)
        {
            _taskDetailDal = taskDetailDal;
        }
    
        public bool Add(TaskDetail taskDetail)
        {
            return _taskDetailDal.Add(taskDetail);
        }

        public bool Delete(int taskId)
        {
            return _taskDetailDal.Delete(new TaskDetail { TaskId = taskId });
        }

        public TaskDetail GetTaskDetail(int taskId)
        {
            return _taskDetailDal.Get(t => t.TaskId == taskId);
        }

        public bool Update(TaskDetail taskDetail)
        {
            throw new NotImplementedException();
        }
    }
}
