using DomainModel.Entities;

namespace DomainService.Abstrack
{
    public interface ICustomerService
    {
        Task<Customer> AddAsync(Customer entity);
        Task<IList<Customer>> GetAllAsync();        
        Task<Customer> GetByIdAsync(long id);
        Task<Customer> UpdateAsync(Customer entity);
        Task RemoveAsync(Customer entity);
    }
}
