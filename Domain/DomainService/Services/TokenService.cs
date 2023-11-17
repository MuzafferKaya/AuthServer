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

        public IList<Claim> GetClaims(User entity)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, entity.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, entity.Email!),
                new Claim(ClaimTypes.Name, entity.UserName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            return claims;
        }

        public AuthenticationTokenResponse CreateToken(User entity)
        {
            var expiration = DateTime.UtcNow.AddHours(_jwtSettings.Expiration);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key!));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: GetClaims(entity),
                expires: expiration,
                signingCredentials: signingCredentials
                );

            AuthenticationTokenResponse tokenResponse = new AuthenticationTokenResponse()
            {
                accesToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                accesTokenExpiration = expiration
            };

            return tokenResponse;
        }
    }
}
