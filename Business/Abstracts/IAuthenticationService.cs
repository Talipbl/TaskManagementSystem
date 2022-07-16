using Entity.Concretes.DTO;
using Entity.Concretes.Models;
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
        bool Register(UserRegisterDTO userRegister);
        bool Login(UserLoginDTO userLogin);
        AccessToken CreateAccessToken(User user);
    }
}
