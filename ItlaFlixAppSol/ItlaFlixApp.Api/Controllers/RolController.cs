using System.Collections.Generic;
using ItlaFlixApp.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItlaFlixApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolRepository _repository;
        public RolController (IRolRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<RolController>
        [HttpGet]
        public IActionResult Get()
        {
            var rol = _repository.GetEntities();
            return Ok(rol);
        }
      
        // GET api/<RolController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RolController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RolController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RolController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}