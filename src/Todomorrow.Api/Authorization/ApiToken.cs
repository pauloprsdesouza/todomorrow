using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Todomorrow.Domain.Users;

namespace Todomorrow.Api.Authorization
{
    public class ApiToken
    {
        private readonly JwtOptions _jwtOptions;

        public User User { get; private set; }

        private List<string> Roles { get; set; } = new List<string>();

        public ApiToken(IOptions<JwtOptions> jwtOptions, User user)
        {
            _jwtOptions = jwtOptions.Value;
            User = user;
        }

        public ApiToken(IOptions<JwtOptions> jwtOptions, UserRole userCompanyRoleModel)
        {
            _jwtOptions = jwtOptions.Value;
            User = userCompanyRoleModel.User;
            Roles = userCompanyRoleModel.Roles;
        }

        public override string ToString()
        {
            List<Claim> claims = new()
            {
                new Claim("UserId", User.Id.ToString()),
                new Claim("UserEmail", User.Email)
            };

            foreach (string role in Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            JwtSecurityToken token = new(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    key: new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.Secret)),
                    algorithm: SecurityAlgorithms.HmacSha256
                ),
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtOptions.ExpirationTime)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
