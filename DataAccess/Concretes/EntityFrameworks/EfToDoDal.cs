using DataAccess.Abstracts;
using Entity.Concretes.DTO;
using Entity.Concretes.Models;

namespace DataAccess.Concretes.EntityFrameworks
{
    public class EfToDoDal : EfEntityRepositoryDal<ToDo, TaskManagementContext>, IToDoDal
    {
        public ToDo GetLastToDo()
        {
            using (TaskManagementContext context = new TaskManagementContext())
            {
                return context.Set<ToDo>().Take(1).OrderByDescending(x => x.TaskId).First();
            }
        }

        public List<ListUserTaskDTO> GetTodosWithUserId(int userId)
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
                return result.ToList();
            }
        }
    }
}
