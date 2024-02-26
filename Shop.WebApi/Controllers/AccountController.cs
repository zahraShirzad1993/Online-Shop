using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Shop.Appliation.Interfaces;
using Shop.Domain.Models.Enums;
using Shop.Domain.ViewModels.Account;
using System.Security.Claims;

namespace Shop.WebApi.Controllers
{
    public class AccountController : Controller
    {
        #region Constructor
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Register
       
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserViewModel register)
        {

            var result = await _userService.RegisterUser(register);
            switch (result)
            {
                case RegisterUserResult.MobileExists:
                    break;
                case RegisterUserResult.Success:
                    break;
            }
            return Ok(register);
            
        }

        #endregion

        #region login
       
        [HttpPost("login"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel login)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUser(login);
                switch (result)
                {
                    case LoginUserResult.NotFound:
                        break;
                    case LoginUserResult.NotActive:
                        break;
                    case LoginUserResult.IsBlocked:
                        break;
                    case LoginUserResult.Success:
                        var user = await _userService.GetUserByPhoneNumber(login.PhoneNumber);
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,user.PhoneNumber),
                            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
                        };
                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principle = new ClaimsPrincipal(identity);
                        return null;
                }
            }

            return Json(login);
        }
        #endregion

        #region LogOut
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }
        #endregion

        #region Profile

        [HttpGet("GetUserByPhoneNumber")]
        public async Task<IActionResult> GetUserByPhoneNumber(string phoneNumber)
        {

            var result = await _userService.GetUserByPhoneNumber(phoneNumber);
            if (result == null)
                return NotFound();
            return Ok(result);
          
        }
        #endregion
    }
}
