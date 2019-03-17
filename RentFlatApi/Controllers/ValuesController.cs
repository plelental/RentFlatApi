using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentFlatApi.Infrastructure.Model;
using RentFlatApi.Infrastructure.Repository;

namespace RentFlatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IFlatRepository _flatRepository;

        public ValuesController(IFlatRepository flatRepository)
        {
            _flatRepository = flatRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"value1", "value2"};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
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

        [HttpPost("addFlat")]
        public async Task<IActionResult> AddFlat([FromBody] Flat flat)
        {
            if (flat == null)
            {
                return BadRequest();
            }

            await _flatRepository.Add(flat);
            return Created("AddFlat", flat);
        }
    }
}