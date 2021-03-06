using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FakePepeController : ControllerBase
    {
        // GET: api/<FakePepeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FakePepeController>/5
        [HttpGet("pepe/{id}")]
        public string Get(int id)
        {
            return "value"+id;
        }

        // POST api/<FakePepeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FakePepeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FakePepeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
