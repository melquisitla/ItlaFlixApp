using ItlaFlixApp.BL.Contract;
using ItlaFlixApp.BL.Dtos.Rent;
using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItlaFlixApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
       // private readonly IRentRepository RentRepository;
        private readonly IRentService rentService;
        public RentController(IRentService rentService)
        {
           this.rentService=rentService;
        }
        // GET: api/<RentController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.rentService.GetAll();
            return Ok(result);
            
           
        }

        // GET api/<RentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.rentService.GetById(id);
            return Ok(result);
        }

        // POST api/<RentController>
        [HttpPost("SaveRent")]
        public IActionResult Post([FromBody] RentSaveDto rentSaveDto)
        {
            var result = this.rentService.SaveRent(rentSaveDto); 
            return Ok(result);


        }

        // PUT api/<RentController>/5
        [HttpPut("UpdateRent")]
        public IActionResult Put( [FromBody] RentUpdateDto rentUpdateDto)
        {
            var result = this.rentService.UpdateRent(rentUpdateDto);
            return Ok(result);
        }

        // DELETE api/<RentController>/5
        [HttpDelete("DeleteRent")]
        public IActionResult Remove([FromBody] RentRemoveDto rentRemoveDto)
        {
            var result = this.rentService.RemoveRent(rentRemoveDto);
            return Ok( result);
        }
    }

}
