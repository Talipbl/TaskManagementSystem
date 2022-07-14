using Business.Abstracts;
using DataAccess.Abstracts;
using Entity.Concretes.Models;

namespace Business.Concretes
{
    public class PasswordManager : IPasswordService
    {
        IPasswordDal _passwordDal;
        public PasswordManager(IPasswordDal passwordDal)
        {
            _passwordDal = passwordDal;
        }

        public bool Add(Password password)
        {
            return _passwordDal.Add(password);
        }

        public bool Delete(int userId)
        {
            return _passwordDal.Delete(new Password { UserId = userId });
        }

        public Password GetPassword(int userId)
        {
            return _passwordDal.Get(u=>u.UserId == userId);
        }

        public bool Update(Password password)
        {
            return _passwordDal.Update(password);   
        }
    }
}
