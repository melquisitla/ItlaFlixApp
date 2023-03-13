using ItlaFlixApp.BL.Contract;
using ItlaFlixApp.BL.Dtos.Sale;
using ItlaFlixApp.BL.Dtos.User;
using ItlaFlixApp.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItlaFlixApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.userService.GetAll();

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // GET api/<UserController>/5
        [HttpGet("{cod_usuario}")]
        public IActionResult Get(int cod_usuario)
        {
            var result = this.userService.GetById(cod_usuario);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/<UserController>
        [HttpPost("SaveUser")]
        public IActionResult Post([FromBody] UserSaveDto userSaveDto)
        {
            var result = this.userService.SaveUser(userSaveDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // PUT api/<UserController>/5
        [HttpPut("UpdateUser")]
        public IActionResult Put([FromBody] UserUpdateDto userUpdateDto)
        {
            var result = this.userService.UpdateUser(userUpdateDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("RemoveUser")]
        public IActionResult Delete([FromBody] UserRemoveDto userRemoveDto)
        {
            var result = this.userService.RemoveUser(userRemoveDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
