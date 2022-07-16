using Entity.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concretes.DTO
{
    public class UserRegisterDTO : IDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MailAdress { get; set; }
    }
}
