using Business.Abstracts;
using DataAccess.Abstracts;
using Entity.Concretes.DTO;
using Entity.Concretes.Models;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IPasswordService _passwordService;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public bool Add(User user)
        {
            var checkUser = _userDal.Get(u => u.MailAdress == user.MailAdress);
            if (checkUser == null)
            {
                return _userDal.Add(user);
            }
            return false;
        }

        public bool Delete(int userId)
        {
            return _userDal.Delete(new User { UserId = userId });
        }

        public User GetUser(int userId)
        {
            return _userDal.Get(u => u.UserId == userId);
        }

        public User GetUserByMail(string userMailAddress)
        {
            return _userDal.Get(u => u.MailAdress == userMailAddress);
        }

        public List<User> GetUsers()
        {
            return _userDal.GetAll();
        }

        public bool Update(User user)
        {
            return _userDal.Update(user);
        }
    }
}
