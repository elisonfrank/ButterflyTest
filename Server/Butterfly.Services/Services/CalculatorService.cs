using Butterfly.Services.Interfaces;

namespace Butterfly.Services.Services
{
    public class CalculatorService : ICalculatorService
    {
        public float Add(float number1, float number2)
        {
            return number1 + number2;
        }

        public float Divide(float number1, float number2)
        {
            if (number2 <= 0)
                throw new Exception("Can't divide by zero");

            return number1 / number2;
        }

        public float Multiply(float number1, float number2)
        {
            return number1 * number2;
        }

        public float Subtract(float number1, float number2)
        {
            return number1 - number2;
        }
    }
}
