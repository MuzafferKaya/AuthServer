using DomainModel.Entities;
using DomainModel.Repository;
using DomainService.Abstrack;

namespace DomainService.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IPasswordHasherService _passwordHasher;

        public UserService(IRepository<User> repository, IPasswordHasherService passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
        }

        public async Task<long> AddAsync(User entity)
        {
            entity.NormalizedUserName = entity.UserName!.ToLower();
            entity.NormalizedEmail = entity.Email!.ToLower();
            entity.PasswordHash = _passwordHasher.HashPassword(entity.PasswordHash!);
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _repository.SingleOrDefaultAsync(x => x.NormalizedEmail == email.ToLower());
        }
    }
}
