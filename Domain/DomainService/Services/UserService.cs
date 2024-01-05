using DomainModel.Entities;
using DomainModel.Repository;
using DomainService.Abstrack;

namespace DomainService.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IPasswordService _password;

        public UserService(IRepository<User> repository, IPasswordService password)
        {
            _repository = repository;
            _password = password;
        }

        public async Task<User> AddAsync(User entity)
        {
            var user = GetByEmailAsync(entity.Email!).Result;
            if (user != null)
                throw new Exception("This email is already in use");

            entity.NormalizedEmail = entity.Email!.ToLower();
            entity.NormalizedUserName = entity.UserName!.ToLower();
            entity.PasswordHash = _password.HashPassword(entity.PasswordHash!);
            await _repository.AddAsync(entity);

            return entity;
        }

        public async Task<IList<User>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _repository.SingleOrDefaultAsync(x => x.NormalizedEmail == email.ToLower());
        }

        public async Task<User> UpdateAsync(User entity)
        {
            await _repository.UpdateAsync(entity);
            return entity;
        }
    }
}
