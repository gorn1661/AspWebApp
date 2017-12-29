using bankWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bankWebApi.Controllers
{
    [Route("bank/[controller]")]
    public class ApplicationController : Controller
    {
        IBankDataProvider _bProvider;

        public ApplicationController(IBankDataProvider bProvider){
            _bProvider = bProvider;
        }
    }
}