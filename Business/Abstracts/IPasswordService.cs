using Entity.Concretes.Models;
using Services.Result.Abstracts;

namespace Business.Abstracts
{
    public interface IPasswordService
    {
        IResult Add(Password password);
        IResult Update(Password password);
        IResult Delete(int userId);
        IDataResult<Password> GetPassword(int userId);
    }
}
