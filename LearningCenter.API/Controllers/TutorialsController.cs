using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningCenter.API.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenter.API.Controllers
{    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TutorialsController : ControllerBase
    {
        // GET: api/Tutorials
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Tutorials/5
        [HttpGet("{id}", Name = "GetTutorial")]
        public string Get([FromQuery] int id)
        {
            return "value";
        }

        // POST: api/Tutorials
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Tutorials/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Tutorials/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
