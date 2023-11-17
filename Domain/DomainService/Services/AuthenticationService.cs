using DomainService.Abstrack;
using Dto.Request.Authentication;
using Dto.Response.Authentication;

namespace DomainService.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasherService _passwordHasherService;
        private readonly ITokenService _tokenService;

        public AuthenticationService(IUserService userService, IPasswordHasherService passwordHasherService, ITokenService tokenService)
        {
            _userService = userService;
            _passwordHasherService = passwordHasherService;
            _tokenService = tokenService;
        }

        public async Task<AuthenticationTokenResponse> CreateTokenAsync(AuthenticationLoginRequest entity)
        {
            var user = await _userService.GetByEmailAsync(entity.email!);
            if (user == null || !_passwordHasherService.VerifyHashedPassword(user.PasswordHash!, entity.password!))
                return null;

            var token = _tokenService.CreateToken(user);
            return token;
        }
    }
}
