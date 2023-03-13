using ItlaFlixApp.BL.Contract;
using ItlaFlixApp.BL.Dtos.Sale;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItlaFlixApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService saleService;

        public SaleController(ISaleService saleService)
        {
            this.saleService = saleService;
        }
        // GET: api/<SaleController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.saleService.GetAll();

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // GET api/<SaleController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.saleService.GetById(id);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/<SaleController>
        [HttpPost("SaveSale")]
        public IActionResult Post([FromBody] SaleSaveDto saleSaveDto)
        {
            var result = this.saleService.SaveSale(saleSaveDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // PUT api/<SaleController>/5
        [HttpPut("UpdateSale")]
        public IActionResult Put([FromBody] SaleUpdateDto saleUpdateDto)
        {
            var result = this.saleService.UpdateSale(saleUpdateDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // DELETE api/<SaleController>/5
        [HttpDelete("RemoveSale")]
        public IActionResult Remove([FromBody] SaleRemoveDto saleRemoveDto)
        {
            var result = this.saleService.RemoveSale(saleRemoveDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
