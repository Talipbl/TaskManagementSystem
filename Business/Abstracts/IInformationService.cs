using Entity.Concretes.Models;
using Services.Result.Abstracts;

namespace Business.Abstracts
{
    public interface IInformationService
    {
        IResult Add(Information ınformation);
        IResult Update(Information ınformation);
        IResult Delete(int informationId);
        IDataResult<List<Information>> GetInformations();
        IDataResult<Information> GetInformation(int informationId);
    }
}
