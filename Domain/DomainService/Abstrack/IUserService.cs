using DomainModel.Entities;

namespace DomainService.Abstrack
{
    public interface IUserService
    {
        Task<long> AddAsync(User entity);
        Task<User> GetByEmailAsync(string email);
    }
}
