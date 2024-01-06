using Dto.Request.Authentication;
using Dto.Response;
using Dto.Response.Authentication;

namespace DomainService.Abstrack
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> CreateTokenAsync(AuthenticationRequest entity);
    }
}
