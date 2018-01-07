using bankWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace bankWebApi.Controllers
{
    [Route("bank/[controller]")]
    public class AccountController : Controller
    {
        IBankDataProvider _bProvider;

        public AccountController(IBankDataProvider bProvider)
        {
            _bProvider = bProvider;
        }

        [HttpGet("signInView")]
        public IActionResult LogIn(){
            return View();
        }

        [HttpPost("employeeSignIn")]
        public void EmployeeSignIn([FromBody] string login, [FromBody] string password)
        {
            HttpContext.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                                                    _bProvider.EmployeeSignIn(login, password));
        }

        [HttpPost("clientSignIn")]
        public void ClientSignIn([FromBody] string login, [FromBody] string password)
        {
            HttpContext.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                                                    _bProvider.ClientSignIn(login, password));
        }

        [HttpGet("signOut")]
        public void SignOut()
        {
            HttpContext.Authentication.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}