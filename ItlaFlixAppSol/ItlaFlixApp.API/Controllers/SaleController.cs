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
    public class SaleController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;

        public SaleController(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }
        // GET: api/<SaleController>
        [HttpGet]
        public IActionResult Get()
        {
            var sales = _saleRepository.GetEntities();
            return Ok(sales);
        }

        // GET api/<SaleController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var sale = _saleRepository.GetEntity(id);
            return Ok(sale);
        }

        // POST api/<SaleController>
        [HttpPost("SaveSale")]
        public IActionResult Post([FromBody] Sale sale)
        {
            _saleRepository.Save(sale);
            return Ok();
        }

        // PUT api/<SaleController>/5
        [HttpPut("UpdateSale")]
        public IActionResult Put([FromBody] Sale sale)
        {
            _saleRepository.Update(sale);
            return Ok();
        }

        // DELETE api/<SaleController>/5
        [HttpDelete("RemoveSale")]
        public IActionResult Remove([FromBody] Sale sale)
        {
            _saleRepository.Remove(sale);
            return Ok();
        }
    }
}
