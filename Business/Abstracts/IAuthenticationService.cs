using Entity.Concretes.DTO;
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

    }
}
