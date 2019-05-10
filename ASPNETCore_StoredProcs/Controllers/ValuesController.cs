using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCore_StoredProcs.Data;
using ASPNETCore_StoredProcs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCore_StoredProcs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ValuesRepository _repository;

        public ValuesController(ValuesRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Value>>> Get()
        {
            return await _repository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Value>> Get(int id)
        {
            var response = await _repository.GetById(id);
            if (response == null) { return NotFound(); }
            return response;
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] Value value)
        {
            await _repository.Insert(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           await _repository.DeleteById(id);
        }
    }
}
