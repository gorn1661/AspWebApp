using bankWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bankWebApi.Controllers
{
    [Route("bank/[controller]")]
    public class TransactionController : Controller
    {
        IBankDataProvider _bProvider;

        public TransactionController(IBankDataProvider bProvider){
            _bProvider = bProvider;
        }
    }
}