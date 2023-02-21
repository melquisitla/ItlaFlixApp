using ItlaFlixApp.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ItlaFlixApp.DAL.Models;
using ItlaFlixApp.DAL.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItlaFlixApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        // GET: api/<MovieController>
        [HttpGet]
        public IEnumerable<MovieModel> Get()
        {
            return _movieRepository.GetAll();
        }

        // GET api/<MovieController>/5
        [HttpGet("cod_pelicula")]
        public IActionResult Get(int cod_pelicula)
        {
            var movie = _movieRepository.Get(cod_pelicula);
            return Ok(movie);
        }

        // POST api/<MovieController>
        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            _movieRepository.Add(movie);
            return Ok();
        }

        // PUT api/<MovieController>/5
        [HttpPut("")]
        public IActionResult Put( [FromBody] Movie movie)
        {
            _movieRepository.Update(movie);
            return Ok();
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("")]
        public IActionResult Delete([FromBody] Movie movie)
        {
            _movieRepository.Delete(movie);
            return Ok();
        }
    }
    
}
