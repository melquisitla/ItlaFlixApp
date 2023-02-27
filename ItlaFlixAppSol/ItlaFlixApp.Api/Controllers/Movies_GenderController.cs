using Microsoft.AspNetCore.Mvc;
using ItlaFlixApp.DAL.Interfaces;
using System.Collections.Generic;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Model;
using System.Reflection;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItlaFlixApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Movies_GenderController : ControllerBase
    {
        private readonly IMovies_GenderRepository _movies_genderRepository;

        public Movies_GenderController(IMovies_GenderRepository moviegenderRepository)
        {
            _movies_genderRepository = moviegenderRepository;
        }
        // GET: api/<Movies_GenderController>
        [HttpGet]
        public IActionResult Get()
        {
            var movieGender = _movies_genderRepository.GetEntities();
            return Ok(movieGender);
        }

        // GET api/<Movies_GenderController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int cod_genero)
        {
            var movie = _movies_genderRepository.GetEntity(cod_genero);
            return Ok(movie);
        }

        // POST api/<Movies_GenderController>
        [HttpPost]
        public IActionResult Post([FromBody] Movies_Gender gender)
        {
            _movies_genderRepository.Save(gender);
            return Ok();
        }

        // PUT api/<Movies_GenderController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Movies_Gender gender)
        {
            _movies_genderRepository.Update(gender);
            return Ok();
        }

        // DELETE api/<Movies_GenderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] Movies_Gender gender)
        {
            _movies_genderRepository.Remove(gender);
            return Ok();
        }
    }
}
