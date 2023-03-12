using Microsoft.AspNetCore.Mvc;
using ItlaFlixApp.DAL.Interfaces;
using System.Collections.Generic;
using ItlaFlixApp.DAL.Models;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.BL.Contract;
using ItlaFlixApp.BL.Dtos.Gender;
using ItlaFlixApp.BL.Dtos.Movie;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItlaFlixApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        
        private readonly IGenderServices genderServices;

        public GenderController(IGenderServices genderServices)
        {
            this.genderServices = genderServices;
        }
        // GET: api/<GenderController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.genderServices.GetAll();

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // GET api/<GenderController>/5
        [HttpGet("cod_genero")]
        public IActionResult Get(int cod_genero)
        {
            var result = this.genderServices.GetById(cod_genero);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/<GenderController>
        [HttpPost]
        public IActionResult Post([FromBody] GenderSaveDto genderSaveDto)
        {
            var result = this.genderServices.SaveGender(genderSaveDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // PUT api/<GenderController>/5
        [HttpPut("")]
        public IActionResult Put( [FromBody] GenderUpdateDto genderUpdateDto)
        {
            var result = this.genderServices.UpdateGender(genderUpdateDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // DELETE api/<GenderController>/5
        [HttpDelete("")]
        public IActionResult Delete([FromBody] GenderRemoveDto genderRemoveDto)
        {
            var result = this.genderServices.RemoveGender(genderRemoveDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
