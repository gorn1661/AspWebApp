using System.Collections.Generic;
using System.Text;
using bankWebApi.Services.DatabaseModels;
using bankWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bankWebApi.Controllers
{
    [Route("bank/[controller]")]
    public class ClientsController : Controller
    {
        IBankDataProvider _bProvider;

        public ClientsController(IBankDataProvider bProvider){
            _bProvider = bProvider;
        }

        [HttpGet("getClients")]
        public IEnumerable<ClientModel> getClients(){
            return _bProvider.getAllClients().Result;
        }
    }
}