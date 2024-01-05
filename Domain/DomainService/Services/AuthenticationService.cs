using DomainService.Abstrack;
using Dto.Request.Authentication;
using Dto.Response.Authentication;

namespace DomainService.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;

        public AuthenticationService(IUserService userService, IRoleService roleService, IPasswordService passwordService, ITokenService tokenService)
        {
            _userService = userService;
            _roleService = roleService;
            _passwordService = passwordService;
            _tokenService = tokenService;
        }

        public async Task<AuthenticationTokenResponse> CreateTokenAsync(AuthenticationRequest entity)
        {
            var user = await _userService.GetByEmailAsync(entity.email!);
            if (user == null || !_passwordService.VerifyHashedPassword(user.PasswordHash!, entity.password!))
                throw new Exception("Incorrect email or password");

            var role = await _roleService.GetByIdAsync(user.RoleId);
            user.Role.RoleName = role.RoleName;

            return _tokenService.CreateToken(user);
        }
    }
}
