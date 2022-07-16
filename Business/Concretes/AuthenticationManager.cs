using Business.Abstracts;
using Entity.Concretes.DTO;
using Entity.Concretes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class AuthenticationManager : IAuthenticationService
    {
        IUserService _userService;
        IPasswordService _passwordService;

        public AuthenticationManager(IUserService userService, IPasswordService passwordService)
        {
            _userService = userService;
            _passwordService = passwordService;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public bool Register(UserRegisterDTO userRegister)
        {
            byte[] passwordSalt, passwordHash;
            CreatePasswordHash(userRegister.Password, out passwordHash, out passwordSalt);
            User user = new User()
            {
                FirstName = userRegister.FirstName,
                LastName = userRegister.LastName,
                MailAdress = userRegister.MailAdress,
                PhoneNumber = userRegister.PhoneNumber
            };
            if (_userService.Add(user))
            {
                var userId = _userService.GetUserByMail(userRegister.MailAdress).UserId;
                Password password = new Password()
                {
                    UserId = userId,
                    PasswordSalt = passwordSalt,
                    PasswordHash = passwordHash
                };
                return _passwordService.Add(password);
            }
            return false;
        }
    }
}
