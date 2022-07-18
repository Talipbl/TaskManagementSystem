using Entity.Abstracts;
using Entity.Concretes.Models;
using Services.Result.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Security.JWT
{
    public class AccessTokenDTO : IDto
    {
        public IDataResult<AccessToken> AccessToken { get; set; }
        public IDataResult<User> User { get; set; }
    }
}
