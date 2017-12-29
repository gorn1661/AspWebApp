using bankWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bankWebApi.Controllers
{
    [Route("bank/[controller]")]
    public class AccountController : Controller
    {
        IBankDataProvider _bProvider;

        public AccountController(IBankDataProvider bProvider){
            _bProvider = bProvider;
        }
    }
}