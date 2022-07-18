using Entity.Concretes.DTO;
using Entity.Concretes.Models;
using Services.Result.Abstracts;
using System.Linq.Expressions;

namespace Business.Abstracts
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(int userId);
        IDataResult<List<User>> GetUsers();
        IDataResult<User> GetUser(int userId);
        IDataResult<User> GetUserByMail(string userMailAddress);
    }
}
