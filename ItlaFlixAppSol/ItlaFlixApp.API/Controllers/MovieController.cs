using ItlaFlixApp.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ItlaFlixApp.DAL.Models;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.BL.Contract;
using ItlaFlixApp.BL.Dtos.Movie;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItlaFlixApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        
        private readonly IMovieServices movieServices;

        public MovieController(IMovieServices movieServices)
        {
            this.movieServices = movieServices;
        }
        // GET: api/<MovieController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.movieServices.GetAll();

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);         
        }

        // GET api/<MovieController>/5
        [HttpGet("cod_pelicula")]
        public IActionResult Get(int cod_pelicula)
        {
            var result = this.movieServices.GetById(cod_pelicula);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/<MovieController>
        [HttpPost]
        public IActionResult Post([FromBody] MovieSaveDto movieSaveDto)
        {
            var result = this.movieServices.SaveMovie(movieSaveDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // PUT api/<MovieController>/5
        [HttpPut("")]
        public IActionResult Put( [FromBody] MovieUpdateDto movieUpdateDto)
        {
            var result = this.movieServices.UpdateMovie(movieUpdateDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("")]
        public IActionResult Delete([FromBody] MovieRemoveDto movieRemoveDto)
        {
            var result = this.movieServices.RemoveMovie(movieRemoveDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
    
}
