using Entity.Concretes.Models;
using Services.Result.Abstracts;

namespace Business.Abstracts
{
    public interface ITaskDetailService
    {
        IResult Add(TaskDetail taskDetail);
        IResult Update(TaskDetail taskDetail);
        IResult Delete(int taskId);
        IDataResult<TaskDetail> GetTaskDetail(int taskDetailId);
    }
}
