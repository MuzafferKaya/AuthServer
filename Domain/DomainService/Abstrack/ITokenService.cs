using DomainModel.Entities;
using Dto.Response.Authentication;

namespace DomainService.Abstrack
{
    public interface ITokenService
    {
        AuthenticationResponse CreateToken(User entity);
    }
}
