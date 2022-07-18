using Business.Abstracts;
using DataAccess.Abstracts;
using Entity.Concretes.DTO;
using Entity.Concretes.Models;
using Services.Constants;
using Services.Result;
using Services.Result.Abstracts;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (_userDal.Add(user))
            {
                return new SuccessResult(MessageHelper.CreateMessage(Messages.User, Messages.Added));
            }
            return new ErrorResult(MessageHelper.CreateMessage(Messages.User, Messages.InsertError));
        }

        public IResult Delete(int userId)
        {
            if (_userDal.Delete(new User { UserId = userId }))
            {
                return new SuccessResult(MessageHelper.CreateMessage(Messages.User, Messages.Deleted));
            }
            return new ErrorResult(MessageHelper.CreateMessage(Messages.User, Messages.DeletionError));
        }

        public IDataResult<User> GetUser(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId));
        }

        public IDataResult<User> GetUserByMail(string userMailAddress)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.MailAdress == userMailAddress));
        }

        public IDataResult<List<User>> GetUsers()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IResult Update(User user)
        {
            if (_userDal.Update(user))
            {
                return new SuccessResult(MessageHelper.CreateMessage(Messages.User, Messages.Updated));
            }
            return new ErrorResult(MessageHelper.CreateMessage(Messages.User, Messages.UpdateError));
        }
    }
}
