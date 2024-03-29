using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using RedisSample.Models;

namespace RedisSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ITest _test;
        public ValuesController(IDistributedCache distributedCache, ApplicationDbContext context, IServiceProvider serviceProvider, ITest test)
        {
            _test = test;
        }

        // GET api/values
        [HttpGet("{id}")]
        public ActionResult<Task> Get(int id)
        {
            return Ok(_test.Get(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
