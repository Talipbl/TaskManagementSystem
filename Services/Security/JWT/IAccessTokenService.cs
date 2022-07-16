using Entity.Concretes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Security.JWT
{
    public interface IAccessTokenService
    {
        AccessToken CreateAccessToken(User user);
    }
}
