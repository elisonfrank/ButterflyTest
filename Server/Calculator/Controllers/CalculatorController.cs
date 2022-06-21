using Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Calculator.Models;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] decimal number1, [FromForm] decimal number2)
        {
            try
            {
                return Json(_calculatorService.Add(number1, number2));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(StatusCodes.Status400BadRequest, ex.Message));
            }
        }

        [HttpPost("subtract")]
        public IActionResult Subtract([FromForm] decimal number1, [FromForm] decimal number2)
        {
            try
            {
                return Json(_calculatorService.Subtract(number1, number2));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(StatusCodes.Status400BadRequest, ex.Message));
            }
        }

        [HttpPost("divide")]
        public IActionResult Divide([FromForm] decimal number1, [FromForm] decimal number2)
        {
            try
            {
                return Json(_calculatorService.Divide(number1, number2));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(StatusCodes.Status400BadRequest, ex.Message));
            }
        }

        [HttpPost("multiply")]
        public IActionResult Multiply([FromForm] decimal number1, [FromForm] decimal number2)
        {
            try
            {
                return Json(_calculatorService.Multiply(number1, number2));
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(StatusCodes.Status400BadRequest, ex.Message));
            }
        }
    }
}
