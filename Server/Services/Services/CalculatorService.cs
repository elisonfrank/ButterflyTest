using Services.Interfaces;

namespace Services.Services
{
    public class CalculatorService : ICalculatorService
    {
        public decimal Add(decimal number1, decimal number2)
        {
            return number1 + number2;
        }

        public decimal Divide(decimal number1, decimal number2)
        {
            if (number2 <= 0)
                throw new Exception("Can't divide by zero");

            return number1 / number2;
        }

        public decimal Multiply(decimal number1, decimal number2)
        {
            return number1 * number2;
        }

        public decimal Subtract(decimal number1, decimal number2)
        {
            return number1 - number2;
        }
    }
}
