using Business.Abstracts;
using Entity.Concretes.Models;
using System.Linq.Expressions;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        public bool Add(User user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int userId)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public User GetUserByMail(string userMailAddress)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers(Expression<Func<ToDo, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public bool Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
