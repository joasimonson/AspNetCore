using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using AspNetCore.Domain.DTO;
using AspNetCore.Domain.Repository;
using AspNetCore.Domain.Security;
using AspNetCore.Domain.Interfaces.Services.User;
using Microsoft.IdentityModel.Tokens;

namespace AspNetCore.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly SigningConfigurations _signingConfigurations;

        public LoginService(IUserRepository userRepository, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations)
        {
            this._signingConfigurations = signingConfigurations;
            this._tokenConfigurations = tokenConfigurations;
            this._userRepository = userRepository;
        }

        public async Task<object> FindByLogin(LoginDTO user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Email))
            {
                return Fail();
            }

            var baseUser = await _userRepository.FindByLogin(user.Email);

            if (baseUser == null)
            {
                return Fail();
            }
            else
            {
                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);
                string token = GenereteJwtToken(user, createDate, expirationDate);

                return Success(user, token, createDate, expirationDate);
            }
        }

        private object Success(LoginDTO user, string token, DateTime createDate, DateTime expirationDate)
        {
            return new
            {
                authenticated = true,
                created = createDate,
                expiration = expirationDate,
                accessToken = token,
                userName = user.Email,
                message = "Login efetuado com sucesso"
            };
        }

        private object Fail()
        {
            return new
            {
                authenticated = false,
                message = "Falha ao autenticar"
            };
        }

        public string GenereteJwtToken(LoginDTO user, DateTime createDate, DateTime expirationDate)
        {
            var genericIdentoty = new GenericIdentity(user.Email);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
            };

            var claimsIdentity = new ClaimsIdentity(genericIdentoty, claims);

            var handler = new JwtSecurityTokenHandler();

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor()
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.Credentials,
                Subject = claimsIdentity,
                NotBefore= createDate,
                Expires = expirationDate
            });

            string token = handler.WriteToken(securityToken);

            return token;
        }
    }
}