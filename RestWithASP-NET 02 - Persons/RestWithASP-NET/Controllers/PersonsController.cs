using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Model;
using RestWithASPNET.Services;

namespace RestWithASP_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET persons/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_personService.FindAll());
        }

        // GET persons/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(long id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST persons/values
        [HttpPost]
        public ActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personService.Create(person));
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personService.Update(person));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();

        }
    }
}
