using ItlaFlixApp.DAL.Interfaces;
using ItlaFlixApp.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItlaFlixApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;

        public SaleController(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }
        // GET: api/<SaleController>
        [HttpGet]
        public IEnumerable<SaleModel> Get()
        {
            return _saleRepository.GetAll();
        }

        // GET api/<SaleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SaleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SaleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SaleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
