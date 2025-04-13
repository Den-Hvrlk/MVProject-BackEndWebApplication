using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MVProject.Application.Interfaces.Auth;
using MVProject.Domain.Entities;

namespace MVProject.Infrastructure
{
    public class JwtProvider : IJwtProvider
    {
        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY"))
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha384);

            var expires = DateTime.UtcNow.AddMinutes(
                double.TryParse(Environment.GetEnvironmentVariable("JWT_EXPIRES"), out var minutes) ? minutes : 15
            );
            var token = new JwtSecurityToken(
                issuer: Environment.GetEnvironmentVariable("JWT_ISSUER"),
                audience: Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
