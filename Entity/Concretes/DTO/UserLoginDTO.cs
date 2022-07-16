using Entity.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concretes.DTO
{
    public class UserLoginDTO : IDto
    {
        public string EMail { get; set; }
        public string Password { get; set; }
    }
}
