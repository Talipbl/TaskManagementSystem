using Business.Abstracts;
using Entity.Concretes.Models;
using System.Linq.Expressions;

namespace Business.Concretes
{
    public class InformationManager : IInformationService
    {
        public bool Add(Information ınformation)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int informationId)
        {
            throw new NotImplementedException();
        }

        public Information GetInformation(int informationId)
        {
            throw new NotImplementedException();
        }

        public List<Information> GetInformations(Expression<Func<Information, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public bool Update(Information ınformation)
        {
            throw new NotImplementedException();
        }
    }
}
