using Entity.Concretes.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Security.JWT
{
    public class AccessTokenService : IAccessTokenService
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        public AccessTokenService(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }
        public AccessToken CreateAccessToken(User user)
        {
            var securityKey = SymmetricSecurityKeyService.Create(_tokenOptions.SecurityKey);
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var signingCredentials = SigningCredentialsService.CreateHmacSha512Signature(securityKey);
            var jwtToken = CreateJwtSecurityToken(signingCredentials, user);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var accessToken = jwtSecurityTokenHandler.WriteToken(jwtToken);
            return new AccessToken()
            {
                Token = accessToken,
                Expiration = _accessTokenExpiration,
                RefreshToken = CreateRefreshToken()
            };
        }
        private string CreateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        private JwtSecurityToken CreateJwtSecurityToken(SigningCredentials signingCredentials, User user)
        {
            var jwtToken = new JwtSecurityToken(
                    issuer: _tokenOptions.Issuer,
                    audience: _tokenOptions.Audience,
                    expires: _accessTokenExpiration,
                    notBefore: DateTime.Now,
                    signingCredentials: signingCredentials,
                    claims: CreateClaims(user)
                    );
            return jwtToken;
        }

        private IEnumerable<Claim> CreateClaims(User user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"));
            claims.Add(new Claim(ClaimTypes.Email, user.MailAdress));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()));
            claims.Add(new Claim(ClaimTypes.MobilePhone, user.PhoneNumber));
            return claims;
        }
    }
}
