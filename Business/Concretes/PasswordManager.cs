using Business.Abstracts;
using DataAccess.Abstracts;
using Entity.Concretes.Models;
using Services.Constants;
using Services.Result;
using Services.Result.Abstracts;

namespace Business.Concretes
{
    public class PasswordManager : IPasswordService
    {
        IPasswordDal _passwordDal;
        public PasswordManager(IPasswordDal passwordDal)
        {
            _passwordDal = passwordDal;
        }

        public IResult Add(Password password)
        {
            if(_passwordDal.Add(password))
            {
                return new SuccessResult(MessageHelper.CreateMessage(Messages.Password, Messages.Added));
            }
            return new ErrorResult(MessageHelper.CreateMessage(Messages.Password, Messages.InsertError));
        }

        public IResult Delete(int userId)
        {
            if (_passwordDal.Delete(new Password { UserId = userId }))
            {
                return new SuccessResult(MessageHelper.CreateMessage(Messages.Password, Messages.Deleted));
            }
            return new ErrorResult(MessageHelper.CreateMessage(Messages.Password, Messages.DeletionError));
        }

        public IDataResult<Password> GetPassword(int userId)
        {
            return new SuccessDataResult<Password>(_passwordDal.Get(u=>u.UserId == userId));
        }

        public IResult Update(Password password)
        {
            if (_passwordDal.Update(password))
            {
                return new SuccessResult(MessageHelper.CreateMessage(Messages.Password, Messages.Updated));
            }
            return new ErrorResult(MessageHelper.CreateMessage(Messages.Password, Messages.UpdateError));
        }
    }
}
