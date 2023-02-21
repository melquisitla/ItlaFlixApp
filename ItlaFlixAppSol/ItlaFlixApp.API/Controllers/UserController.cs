using ItlaFlixApp.DAL.Entities;
using ItlaFlixApp.DAL.Interfaces;
using ItlaFlixApp.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItlaFlixApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            return _userRepository.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{cod_usuario}")]
        public IActionResult Get(int cod_usuario)
        {
            var user = _userRepository.Get(cod_usuario);
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost("SaveUser")]
        public IActionResult Post([FromBody] User user)
        {
            _userRepository.Save(user);
            return Ok();
        }

        // PUT api/<UserController>/5
        [HttpPut("UpdateUser")]
        public IActionResult Put([FromBody] User user)
        {
            _userRepository.Update(user);
            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("RemoveUser")]
        public IActionResult Delete([FromBody] User user)
        {
            _userRepository.Remove(user);
            return Ok();
        }
    }
}
