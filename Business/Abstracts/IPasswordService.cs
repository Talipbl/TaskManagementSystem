using Entity.Concretes.Models;

namespace Business.Abstracts
{
    public interface IPasswordService
    {
        bool Add(Password password);
        bool Update(Password password);
        bool Delete(int userId);
        Password GetPassword(int userId);
    }
}
