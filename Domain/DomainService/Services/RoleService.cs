using DomainModel.Entities;
using DomainModel.Repository;
using DomainService.Abstrack;

namespace DomainService.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _repository;

        public RoleService(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public async Task<Role> AddAsync(Role entity)
        {
            await _repository.AddAsync(entity);
            return entity;
        }

        public async Task<IList<Role>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Role> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Role entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
