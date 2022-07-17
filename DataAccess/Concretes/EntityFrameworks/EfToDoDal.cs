using DataAccess.Abstracts;
using Entity.Concretes.DTO;
using Entity.Concretes.Models;
using Services.Result;
using Services.Result.Abstracts;

namespace DataAccess.Concretes.EntityFrameworks
{
    public class EfToDoDal : EfEntityRepositoryDal<ToDo, TaskManagementContext>, IToDoDal
    {
        public IDataResult<ToDo> GetLastToDo()
        {
            using (TaskManagementContext context = new TaskManagementContext())
            {
                return new SuccessDataResult<ToDo>(context.Set<ToDo>().Take(1).OrderByDescending(x => x.TaskId).First());
            }
        }

        public IDataResult<List<ListUserTaskDTO>> GetTodosWithUserId(int userId)
        {
            using (TaskManagementContext context = new TaskManagementContext())
            {
                var result = from td in context.ToDos
                             join u in context.Users on td.ToId equals u.UserId
                             join c in context.Categories on td.CategoryId equals c.CategoryId
                             where td.ToId == userId

                             select new ListUserTaskDTO
                             {
                                 TaskID = td.TaskId,
                                 CategoryName = c.Name,
                                 Subject = td.Subject,
                                 Description = td.Description,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName
                             };
                return new SuccessDataResult<List<ListUserTaskDTO>>(result.ToList());
            }
        }
    }
}
