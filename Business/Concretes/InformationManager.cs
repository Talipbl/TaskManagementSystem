using Business.Abstracts;
using DataAccess.Abstracts;
using Entity.Concretes.Models;
using Services.Constants;
using Services.Result;
using Services.Result.Abstracts;
using System.Linq.Expressions;

namespace Business.Concretes
{
    public class InformationManager : IInformationService
    {
        IInformationDal _informationDal;
        public InformationManager(IInformationDal informationDal)
        {
            _informationDal = informationDal;
        }

        public IResult Add(Information information)
        {
            if (_informationDal.Add(information))
            {
                return new SuccessResult(MessageHelper.CreateMessage(Messages.Information, Messages.Added));
            }
            return new ErrorResult(MessageHelper.CreateMessage(Messages.Information, Messages.InsertError));
        }

        public IResult Delete(int informationId)
        {
            if (_informationDal.Delete(new Information { InfoId = informationId }))
            {
                return new SuccessResult(MessageHelper.CreateMessage(Messages.Information, Messages.Deleted));
            }
            return new ErrorResult(MessageHelper.CreateMessage(Messages.Information, Messages.DeletionError));
        }

        public IDataResult<Information> GetInformation(int informationId)
        {
            return new SuccessDataResult<Information>(_informationDal.Get(i => i.InfoId == informationId));
        }

        public IDataResult<List<Information>> GetInformations()
        {
            return new SuccessDataResult<List<Information>>(_informationDal.GetAll());
        }

        public IResult Update(Information information)
        {
            if (_informationDal.Update(information))
            {
                return new SuccessResult(MessageHelper.CreateMessage(Messages.Information, Messages.Updated));
            }
            return new ErrorResult(MessageHelper.CreateMessage(Messages.Information, Messages.UpdateError));
        }
    }
}
