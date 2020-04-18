using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FibRest.Models;
using FibRest.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FibRest.Controllers
{
    [EnableCors("localhost")]
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
            try
            {
                return Ok(_fibDbService.GetAll());
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

        [HttpPost]
        public async Task<IActionResult> Calculate([FromBody] FibRequest model)
        {

            if (!ModelState.IsValid)
            {
                return HandleError();
            }

            try
            {
                return Ok(await _fibDbService.CalculateAsync(model));
            }
            catch (Exception e)
            {
                return HandleError(new[] { e.Message });
            }
        }

        private IActionResult HandleError(string[] errorMessages)
        {
            return BadRequest(new ErrorResponse
            {
                ErrorMessages = errorMessages
            });
        }

        private IActionResult HandleError()
        {
            var errorMessages = new List<string>();

            foreach (var modelErrorCollection in ModelState.Values.Select(m => m.Errors))
            {
                foreach (var error in modelErrorCollection)
                {
                    errorMessages.Add(error.ErrorMessage);
                }
            }

            return HandleError(errorMessages.ToArray());
        }
    }
}
