using Dto.Request.Authentication;
using Dto.Response.Authentication;

namespace DomainService.Abstrack
{
    public interface IAuthenticationService
    {
        Task<AuthenticationTokenResponse> CreateTokenAsync(AuthenticationLoginRequest entity);
    }
}
