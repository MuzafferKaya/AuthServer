using DomainModel.Entities;
using System.Linq.Expressions;

namespace DomainService.Abstrack
{
    public interface IUserService
    {
        Task<User> AddAsync(User entity);
        Task<IList<User>> GetAllAsync();
        Task<User> GetByEmailAsync(string email);
        Task<User> UpdateAsync(User entity);
    }
}
