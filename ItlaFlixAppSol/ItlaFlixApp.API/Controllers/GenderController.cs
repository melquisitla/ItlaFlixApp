using Microsoft.AspNetCore.Mvc;
using ItlaFlixApp.DAL.Interfaces;
using System.Collections.Generic;
using ItlaFlixApp.DAL.Models;
using ItlaFlixApp.DAL.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItlaFlixApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderRepository _genderRepository;

        public GenderController(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }
        // GET: api/<GenderController>
        [HttpGet]
        public IEnumerable<GenderModel> Get()
        {
            return _genderRepository.GetAll();
        }

        // GET api/<GenderController>/5
        [HttpGet("cod_genero")]
        public IActionResult Get(int cod_genero)
        {
            var movie = _genderRepository.Get(cod_genero);
            return Ok(movie);
        }

        // POST api/<GenderController>
        [HttpPost]
        public IActionResult Post([FromBody] Gender gender)
        {
            _genderRepository.Add(gender);
            return Ok();
        }

        // PUT api/<GenderController>/5
        [HttpPut("")]
        public IActionResult Put( [FromBody] Gender gender)
        {
            _genderRepository.Update(gender);
            return Ok();
        }

        // DELETE api/<GenderController>/5
        [HttpDelete("")]
        public IActionResult Delete([FromBody] Gender gender)
        {
            _genderRepository.Delete(gender);
            return Ok();
        }
    }
}
