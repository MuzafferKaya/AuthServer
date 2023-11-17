using DomainModel.Entities;
using System.Linq.Expressions;

namespace DomainService.Abstrack
{
    public interface ICustomerService
    {
        Task<long> AddAsync(Customer entity);
        Task<IList<Customer>> GetAllAsync();
        Task<IList<Customer>> WhereAsync(Expression<Func<Customer, bool>> predicate);
        Task<Customer> GetByIdAsync(long id);
        Task<long> UpdateAsync(Customer entity);
        Task RemoveAsync(Customer entity);
    }
}
