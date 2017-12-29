using bankWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bankWebApi.Controllers
{
    [Route("bank/[controller]")]
    public class EmployeeController : Controller
    {
        IBankDataProvider _bProvider;

        public EmployeeController(IBankDataProvider bProvider){
            _bProvider = bProvider;
        }
    }
}