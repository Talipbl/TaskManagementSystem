using Entity.Concretes.Models;

namespace Business.Abstracts
{
    public interface ITaskDetailService
    {
        bool Add(TaskDetail taskDetail);
        bool Update(TaskDetail taskDetail);
        bool Delete(int taskDetailId);
        TaskDetail GetTaskDetail(int taskDetailId);
    }
}
