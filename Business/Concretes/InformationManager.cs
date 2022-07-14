using Business.Abstracts;
using DataAccess.Abstracts;
using Entity.Concretes.Models;
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

        public bool Add(Information information)
        {
            return _informationDal.Add(information);
        }

        public bool Delete(int informationId)
        {
            return _informationDal.Delete(new Information { InfoId = informationId });
        }

        public Information GetInformation(int informationId)
        {
            return _informationDal.Get(i => i.InfoId == informationId);
        }

        public List<Information> GetInformations()
        {
            return _informationDal.GetAll();
        }

        public bool Update(Information information)
        {
            return _informationDal.Update(information);
        }
    }
}
