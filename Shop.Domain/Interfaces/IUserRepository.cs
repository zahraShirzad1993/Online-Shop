
using Shop.Domain.Models.Account;

namespace Shop.Domain.Interfaces
{
    public interface IUserRepository
    {
        #region account
        Task<bool> IsUserExistsPhoneNuber(string phoneNumber);
        Task CreateUser(User user);
        Task<User> GetUserById(int userId);
        Task<User> GetUserByPhoneNumber(string phoneNumber);
        void UpdateUser(User user);
        Task SaveChange();
        #endregion
    }
}
