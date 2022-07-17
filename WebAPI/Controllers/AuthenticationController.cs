﻿using Business.Abstracts;
using Entity.Concretes.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Constants;
using Services.Security.JWT;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        IAuthenticationService _authenticationService;
        IUserService _userService;

        public AuthenticationController(IAuthenticationService authenticationService, IUserService userService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO userLogin)
        {
            var result = _authenticationService.Login(userLogin);
            if (result.Success)
            {
                var loginUser = _userService.GetUserByMail(userLogin.EMail);
                var accessToken = _authenticationService.CreateAccessToken(loginUser);
                if (accessToken != null)
                {
                    return Ok(accessToken);
                }
            }
            return Unauthorized(result.Message);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO userRegister)
        {
            if (_authenticationService.Register(userRegister).Success)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
