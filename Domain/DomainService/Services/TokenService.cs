using DomainModel.Entities;
using DomainService.Abstrack;
using DomainService.Configuration;
using Dto.Response.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DomainService.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;

        public TokenService(IOptions<JwtSettings> options)
        {
            _jwtSettings = options.Value;
        }

        public static IList<Claim> GetClaims(User entity)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, entity.Id.ToString()),
                new Claim(ClaimTypes.Name, entity.UserName!),
                new Claim(ClaimTypes.Role, entity.Role.RoleName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            return claims;
        }

        public AuthenticationResponse CreateToken(User entity)
        {
            return new AuthenticationResponse()
            {
                accesToken = new JwtSecurityTokenHandler().WriteToken(
                    new JwtSecurityToken(
                        issuer: _jwtSettings.Issuer,
                        audience: _jwtSettings.Audience,
                        claims: GetClaims(entity),
                        expires: DateTime.UtcNow.AddHours(_jwtSettings.Expiration),
                        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key!)), SecurityAlgorithms.HmacSha256Signature)
                        )),
                refreshToken = null!
            };
        }
    }
}
