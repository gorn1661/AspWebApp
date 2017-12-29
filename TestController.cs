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
    public class ValuesController : Controller
    {

        IBankDataProvider _bProvider;

        protected ValuesController(IBankDataProvider bProvider)
        {
            _bProvider = bProvider;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return id.ToString();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("fgui543h43fnjk34njkven8t958ty94vmfhuireughdhi4kgdgnji53ugdfhgjkdfug5u9ghdifhgjdfkf")]
        public IEnumerable<ClientModel> addRandomClients(){
            return _bProvider.createClientsRandomly().Result;
        }

        [HttpGet("getClients")]
        public IEnumerable<ClientModel> getClients(){
            return _bProvider.getAllClients().Result;
        }
    }
}
