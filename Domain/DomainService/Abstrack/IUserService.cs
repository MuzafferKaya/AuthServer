using DomainModel.Entities;

namespace DomainService.Abstrack
{
    public interface IUserService
    {
        Task<User> AddAsync(User entity);
        Task<IList<User>> GetAllAsync();
        Task<User> FindByEmailAsync(string email);
        Task UpdateAsync(User entity);
    }
}
