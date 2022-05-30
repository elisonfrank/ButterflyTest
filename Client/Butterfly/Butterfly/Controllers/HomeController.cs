using Butterfly.Models;
using Calculator.Enums;
using Calculator.Helpers;
using Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Butterfly.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CalculatorClient _client;

        public HomeController(ILogger<HomeController> logger, CalculatorClient httpClient)
        {
            _logger = logger;
            _client = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate()
        {
            Save("Number2", (EnumOperations)TempData["Operation"], true, out var calculator);
            calculator.Number1 = Convert.ToDecimal(TempData["Number1"]);

            decimal result = 0;
            var parameters = new Dictionary<string, string>() {
                {"number1", calculator.Number1.ToString() },
                {"number2", calculator.Number2.ToString() }
            };

            switch (calculator.Operation)
            {
                case EnumOperations.Division:
                    result = _client.Divide<decimal>(parameters).GetAwaiter().GetResult();
                    break;

                case EnumOperations.Subtraction:
                    result = _client.Subtract<decimal>(parameters).GetAwaiter().GetResult();
                    break;

                case EnumOperations.Addition:
                    result = _client.Add<decimal>(parameters).GetAwaiter().GetResult();
                    break;

                case EnumOperations.Multiplication:
                    result = _client.Multiply<decimal>(parameters).GetAwaiter().GetResult();
                    break;

                default:
                    break;
            }

            calculator.Result = result;
            calculator.Display = Convert.ToString(calculator.Result);

            TempData["History"] += Convert.ToString(calculator.Result);
            TempData["Display"] = Convert.ToString(calculator.Result);
            TempData["Number1"] = Convert.ToString(calculator.Result);
            TempData["Number2"] = "";
            calculator.History = Convert.ToString(TempData["History"]) ?? "";

            TempData.Keep();
            return View("Index", calculator);
        }

        public IActionResult Clear()
        {
            TempData.Clear();
            return View("Index");
        }

        public IActionResult Digit(int number)
        {
            TempData["Display"] += Convert.ToString(number);
            TempData["History"] += Convert.ToString(TempData["Display"]);

            var calculator = NewCalculatorModel(
                Convert.ToString(TempData["Display"]) ?? "", 
                Convert.ToString(TempData["History"]) ?? ""
            );

            TempData.Keep();
            return View("Index", calculator);
        }

        public IActionResult Division()
        {
            Save("Number1", EnumOperations.Division, false, out var calculator);
            return View("Index", calculator);
        }

        public IActionResult Subtraction()
        {
            Save("Number1", EnumOperations.Subtraction, false, out var calculator);
            return View("Index", calculator);
        }

        public IActionResult Addition()
        {
            Save("Number1", EnumOperations.Addition, false, out var calculator);
            return View("Index", calculator);
        }

        public IActionResult Multiplication()
        {
            Save("Number1", EnumOperations.Multiplication, false, out var calculator);
            return View("Index", calculator);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void Save(string number, EnumOperations operation, bool getResult, out CalculatorModel calculator)
        {
            TempData[number] = TempData["Display"];
            TempData["Display"] = "";
            TempData["Operation"] = operation;

            if (getResult)
                TempData["History"] += " = ";
            else
            {
                switch (operation)
                {
                    case EnumOperations.Division:
                        TempData["History"] += " / ";
                        break;
                    case EnumOperations.Subtraction:
                        TempData["History"] += " - ";
                        break;
                    case EnumOperations.Addition:
                        TempData["History"] += " + ";
                        break;
                    case EnumOperations.Multiplication:
                        TempData["History"] += " * ";
                        break;
                    default:
                        break;
                }
            }

            calculator = NewCalculatorModel(
                Convert.ToString(TempData["Display"]) ?? "",
                Convert.ToString(TempData["History"]) ?? "",
                (EnumOperations)TempData["Operation"]
            );

            if (number.ToUpper() == "NUMBER1")
                calculator.Number1 = Convert.ToDecimal(TempData[number]);
            else
                calculator.Number2 = Convert.ToDecimal(TempData[number]);

            TempData.Keep();
        }

        private CalculatorModel NewCalculatorModel(string display, string history)
        {
            var calculator = new CalculatorModel() { Display = display, History = history };
            return calculator;
        }

        private CalculatorModel NewCalculatorModel(string display, string history, EnumOperations operation)
        {
            var calculator = new CalculatorModel() { Display = display, History = history, Operation = operation };
            return calculator;
        }
    }
}