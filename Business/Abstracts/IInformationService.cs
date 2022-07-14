using Entity.Concretes.Models;
using System.Linq.Expressions;

namespace Business.Abstracts
{
    public interface IInformationService
    {
        bool Add(Information ınformation);
        bool Update(Information ınformation);
        bool Delete(int informationId);
        List<Information> GetInformations(Expression<Func<Information, bool>> filter);
        Information GetInformation(int informationId);
    }
}
