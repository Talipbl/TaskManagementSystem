using Entity.Concretes.DTO;
using Entity.Concretes.Models;
using Services.Result.Abstracts;
using Services.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IAuthenticationService
    {
        IResult Register(UserRegisterDTO userRegister);
        IResult Login(UserLoginDTO userLogin);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
