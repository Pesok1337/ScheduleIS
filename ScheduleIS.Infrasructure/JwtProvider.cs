using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ScheduleIS.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using static ScheduleIS.Infrasructure.JwtProvider;
using System.Security.Claims;
using System.Text;
using ScheduleIS.Application.Interfaces.Auth;


namespace ScheduleIS.Infrasructure
{
    public class JwtProvider(IOptions<JwtOptions> options) : IJwtProvider
    {
        private readonly JwtOptions _options = options.Value;

        public string Generate(User user)
        {
            Claim[] claims =
            [
                new (CustomClaims.UserId, user.Id.ToString()),
                new ("Admin", "true")
            ];

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(_options.ExpiresHours),
                signingCredentials: signingCredentials);

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
   
}
