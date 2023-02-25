using Microsoft.AspNetCore.Mvc;
using ItlaFlixApp.DAL.Interfaces;
using System.Collections.Generic;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Model;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItlaFlixApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Movies_GenderController : ControllerBase
    {
        private readonly IMovies_GenderRepository _movies_genderRepository;

        public Movies_GenderController(IMovies_GenderRepository genderRepository)
        {
            _movies_genderRepository = genderRepository;
        }
        // GET: api/<Movies_GenderController>
        [HttpGet]
        public IEnumerable<Movie_GenderModel> Get()
        {
            return _movies_genderRepository.GetAll();
        }

        // GET api/<Movies_GenderController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int cod_genero)
        {
            var movie = _movies_genderRepository.Get(cod_genero);
            return Ok(movie);
        }

        // POST api/<Movies_GenderController>
        [HttpPost]
        public IActionResult Post([FromBody] Movies_Gender gender)
        {
            _movies_genderRepository.Add(gender);
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
            _movies_genderRepository.Delete(gender);
            return Ok();
        }
    }
}
