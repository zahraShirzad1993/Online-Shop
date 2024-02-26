using Shop.Appliation.Interfaces;
using Shop.Domain.Interfaces;
using Shop.Domain.Models.Account;
using Shop.Domain.Models.Enums;
using Shop.Domain.ViewModels.Account;

namespace Shop.Appliation.Services
{
    public class UserService : IUserService
    {
        #region Constructor
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHelper _passwordHelper;
        public UserService(IUserRepository userRepository, IPasswordHelper passwordHelper)
        {
            _userRepository = userRepository;
            _passwordHelper = passwordHelper;
        }


        #endregion

        #region account
        public async Task<RegisterUserResult> RegisterUser(RegisterUserViewModel register)
        {
            if (!await _userRepository.IsUserExistsPhoneNuber(register.PhoneNumber))
            {
                var user = new User
                {
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                    UserGender = UserGender.UnKnown,
                    Password = register.Password,//_passwordHelper.EncodePasswordMD5(register.Password),
                    PhoneNumber = register.PhoneNumber,
                    Address = "",
                    IsMobileActive = false,
                    MobileActiveCode = new Random().Next(1000, 9999).ToString(),
                    IsDelete = false,
                    PostalCode = ""
                };
                await _userRepository.CreateUser(user);
                await _userRepository.SaveChange();

                return RegisterUserResult.Success;
            }

            return RegisterUserResult.MobileExists;
        }

        public async Task<LoginUserResult> LoginUser(LoginUserViewModel login)
        {
            var user = await _userRepository.GetUserByPhoneNumber(login.PhoneNumber);
            if (user == null) return LoginUserResult.NotFound;
            if (!user.IsMobileActive) return LoginUserResult.NotActive;
            if (user.Password != _passwordHelper.EncodePasswordMD5(login.Password)) return LoginUserResult.NotFound;

            return LoginUserResult.Success;
        }

        public async Task<User> GetUserByPhoneNumber(string phoneNumber)
        {
            return await _userRepository.GetUserByPhoneNumber(phoneNumber);
        }
        #endregion



        #region profile

        public async Task<EditUserProfileViewModel> GetEditUserProfile(int userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user == null) return null;

            return new EditUserProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                //UserGender = user.UserGender
            };
        }

        public async Task<EditUserProfileResult> EditProfile(int userId, EditUserProfileViewModel editUserProfile)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user == null) return EditUserProfileResult.NotFound;

            user.FirstName = editUserProfile.FirstName;
            user.LastName = editUserProfile.LastName;
           
            _userRepository.UpdateUser(user);
            await _userRepository.SaveChange();

            return EditUserProfileResult.Success;
        }

        public async Task<ChangePasswordResult> ChangePassword(int userId, ChangePasswordViewModel changePassword)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user != null)
            {
                var newPassword = _passwordHelper.EncodePasswordMD5(changePassword.NewPassword);
                if (user.Password != newPassword)
                {
                    user.Password = newPassword;
                    _userRepository.UpdateUser(user);
                    await _userRepository.SaveChange();

                    return ChangePasswordResult.Success;
                }
                return ChangePasswordResult.PasswordEqual;
            }
            return ChangePasswordResult.NotFound;
        }

      
        #endregion

    }
}
