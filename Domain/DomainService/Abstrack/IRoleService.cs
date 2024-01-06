using DomainModel.Entities;

namespace DomainService.Abstrack
{
    public interface IRoleService
    {
        Task<Role> AddAsync(Role entity);
        Task<IList<Role>> GetAllAsync();
        Task<Role> GetByIdAsync(long id);
        Task UpdateAsync(Role entity);
    }
}
