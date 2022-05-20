using Butterfly.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ServerCalculator.Models;

namespace ServerCalculator.Controllers
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
        public IActionResult Add(float number1, float number2)
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
        public IActionResult Subtract(float number1, float number2)
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
        public IActionResult Divide(float number1, float number2)
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
        public IActionResult Multiply(float number1, float number2)
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
