using DomainModel.Entities;
using Dto.Response.Authentication;

namespace DomainService.Abstrack
{
    public interface ITokenService
    {
        AuthenticationTokenResponse CreateToken(User entity);
    }
}
