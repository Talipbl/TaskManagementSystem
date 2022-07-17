using Business.Abstracts;
using Services.Security.Helpers;
using Entity.Concretes.DTO;
using Entity.Concretes.Models;
using Services.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Services.Result.Abstracts;
using Services.Result;
using Services.Constants;

namespace Business.Concretes
{
    public class AuthenticationManager : IAuthenticationService
    {
        IUserService _userService;
        IPasswordService _passwordService;
        IAccessTokenService _accessTokenService;
        public AuthenticationManager(IUserService userService, IPasswordService passwordService, IAccessTokenService accessTokenService)
        {
            _userService = userService;
            _passwordService = passwordService;
            _accessTokenService = accessTokenService;
        }
        public IResult Register(UserRegisterDTO userRegister)
        {
            var checkUser = _userService.GetUserByMail(userRegister.MailAdress);
            if (checkUser == null)
            {
                byte[] passwordSalt, passwordHash;
                HashingHelper.CreatePasswordHash(userRegister.Password, out passwordHash, out passwordSalt);
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
                    if (_passwordService.Add(password).Success)
                    {
                        return new SuccessResult(MessageHelper.CreateMessage(Messages.User, Messages.SuccessfullyCreated));
                    }
                }
                return new ErrorResult(MessageHelper.CreateMessage(Messages.User, Messages.InsertError));
            }
            return new ErrorResult(MessageHelper.CreateMessage(Messages.User,Messages.AlreadyExists));
        }

        public IResult Login(UserLoginDTO userLogin)
        {
            var user = _userService.GetUserByMail(userLogin.EMail);
            if (user != null)
            {
                var password = _passwordService.GetPassword(user.UserId);
                return HashingHelper.VerifyPasswordHash(userLogin.Password, password.Data.PasswordHash, password.Data.PasswordSalt);
            }
            return new ErrorResult(MessageHelper.CreateMessage(Messages.UserName,Messages.Incorrect));
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            return new SuccessDataResult<AccessToken>(_accessTokenService.CreateAccessToken(user),MessageHelper.CreateMessage(
                Messages.AccessToken, Messages.SuccessfullyCreated));
        }
    }
}
