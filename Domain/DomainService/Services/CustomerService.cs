using DomainModel.Entities;
using DomainModel.Repository;
using DomainService.Abstrack;

namespace DomainService.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repository;

        public CustomerService(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<Customer> AddAsync(Customer entity)
        {
            await _repository.AddAsync(entity);
            return entity;
        }

        public async Task<IList<Customer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Customer> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Customer entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task RemoveAsync(Customer entity)
        {
            await _repository.RemoveAsync(entity);
        }
    }
}
