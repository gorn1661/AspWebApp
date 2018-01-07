using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankWebApi.Services.DatabaseModels;
using bankWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bankwebapi.Controllers
{
    [Route("test/[controller]")]
    public class TestController : Controller
    {

        IBankDataProvider _bProvider;

        public TestController(IBankDataProvider bProvider)
        {
            _bProvider = bProvider;
        }

        [HttpGet("fgui543h43fnjk34njkven8t958ty94vmfhuireughdhi4kgdgnji53ugdfhgjkdfug5u9ghdifhgjdfkf")]
        public IEnumerable<ClientModel> addRandomClients(){
            return _bProvider.createClientsRandomly().Result;
        }

        [HttpGet("getClients")]
        public IEnumerable<ClientModel> getClients(){
            return _bProvider.getAllClients().Result;
        }

        [HttpGet("ufig874fgyuewgfuttqift546fusgfyeruiu746fgygfbvjkdfgsfyi7e46fgjshfg34i8fygrufgvgdsjhfgu")]
        public IEnumerable<ClientAccountModel> addClientsAccount(){
            return _bProvider.createClientAccountsRandomly().Result;
        }

        [HttpGet("getAccounts")]
        public IEnumerable<ClientAccountModel> getAccounts(){
            return _bProvider.getAllClientsAccount().Result;
        }
    }
}
