
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Interfaces;
using Shop.Domain.Models.Account;
using Shop.Infra.Data.Context;

namespace Shop.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Construtor
        private readonly ShopDbContext _shopDbContext;
        public UserRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        #endregion

        #region User
        public async Task<bool> IsUserExistsPhoneNuber(string phoneNumber)
        {
            return await _shopDbContext.Users.AsQueryable().AnyAsync(c => c.PhoneNumber == phoneNumber);
        }

        public async Task CreateUser(User user)
        {
            await _shopDbContext.Users.AddAsync(user);
        }
        public async Task SaveChange()
        {
            await _shopDbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByPhoneNumber(string phoneNumber)
        {
            return await _shopDbContext.Users.AsQueryable()
                .SingleOrDefaultAsync(c => c.PhoneNumber == phoneNumber);
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _shopDbContext.Users.AsQueryable()
               .SingleOrDefaultAsync(c => c.Id == userId);
        }

        public void UpdateUser(User user)
        {
            _shopDbContext.Users.Update(user);
        }

        #endregion

    }
}
