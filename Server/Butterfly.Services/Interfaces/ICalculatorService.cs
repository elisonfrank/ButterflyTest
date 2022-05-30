namespace Butterfly.Services.Interfaces
{
    public interface ICalculatorService
    {
        decimal Add(decimal number1, decimal number2);
        decimal Subtract(decimal number1, decimal number2);
        decimal Divide(decimal number1, decimal number2);
        decimal Multiply(decimal number1, decimal number2);
    }
}
