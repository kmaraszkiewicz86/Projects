using System;
using System.Linq;
using System.Threading.Tasks;
using FibRest.Models;
using FibRest.Services;
using Microsoft.AspNetCore.Mvc;

namespace FibRest.Controllers
{
    [ApiController]
    [Route("api/FibMathCalculator")]
    public class FibMathCalculatorController : ControllerBase
    {
        private readonly IFibDbService _fibDbService;

        public FibMathCalculatorController(IFibDbService fibDbService)
        {
            _fibDbService = fibDbService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_fibDbService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Calculate([FromBody] FibRequest model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    ErrorMessages = ModelState.Values.Select(m => m.Errors.Select(e => e.ErrorMessage))
                });
            }

            try
            {
                return Ok(await _fibDbService.CalculateAsync(model));
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    ErrorMessages = new[]
                    {
                        e.Message
                    }
                });
            }
        }
    }
}
