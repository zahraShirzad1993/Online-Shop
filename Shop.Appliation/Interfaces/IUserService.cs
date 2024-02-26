using Shop.Domain.Models.Account;
using Shop.Domain.Models.Enums;
using Shop.Domain.ViewModels.Account;

namespace Shop.Appliation.Interfaces
{
    public interface IUserService
    {
        #region account
        Task<RegisterUserResult> RegisterUser(RegisterUserViewModel RegisterUserViewModel);
        Task<LoginUserResult> LoginUser(LoginUserViewModel login);
        Task<User> GetUserByPhoneNumber(string phoneNumber);
        #endregion

        #region Profile
        Task<EditUserProfileViewModel> GetEditUserProfile(int userId);
        Task<EditUserProfileResult> EditProfile(int userId, EditUserProfileViewModel editUserProfile);
        Task<ChangePasswordResult> ChangePassword(int userId, ChangePasswordViewModel changePassword);
        #endregion



    }
}
