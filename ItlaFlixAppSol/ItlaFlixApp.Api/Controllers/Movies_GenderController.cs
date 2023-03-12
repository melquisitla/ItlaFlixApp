using Microsoft.AspNetCore.Mvc;
using ItlaFlixApp.DAL.Interfaces;
using System.Collections.Generic;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Model;
using System.Reflection;
using System.Linq;
using ItlaFlixApp.BL.Contract;
using ItlaFlixApp.BL.Dtos.MovieGender;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItlaFlixApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Movies_GenderController : ControllerBase
    {
        private IMovieGenderService _movieGenderService;

        public Movies_GenderController(IMovieGenderService movieGenderService)
        {
            _movieGenderService = movieGenderService;
        }
        // GET: api/<Movies_GenderController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this._movieGenderService.GetAll();
            if(result.Success)
            {
            return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // GET api/<Movies_GenderController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int cod_genero)
        {
            var result = this._movieGenderService.GetById(cod_genero);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // POST api/<Movies_GenderController>
        [HttpPost("SaveMovieGender")]
        public IActionResult Post([FromBody] MovieGenderSaveDto movieGenderDto)
        {
            var result = this._movieGenderService.SaveMovieGender(movieGenderDto);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // PUT api/<Movies_GenderController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] MovieGenderUpdateDto movieGenderDto)
        {
            var result = this._movieGenderService.UpdateMovieGender(movieGenderDto);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // DELETE api/<Movies_GenderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] MovieGenderRemoveDto movieGenderDto)
        {
            var result = this._movieGenderService.DeleteMovieGender(movieGenderDto);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
