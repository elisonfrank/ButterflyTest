using Services.Services;

namespace Butterfly.UnitTests
{
    public class CalculatorServiceTests
    {
        [TestCase(2, 2, 4)]
        [TestCase(1, 2, 3)]
        [TestCase(2, 4, 6)]
        [TestCase(-2, 2, 0)]
        public void Testing_Add_TwoNumbersAreAdded(decimal n1, decimal n2, decimal result)
        {
            //arrange
            var calculator = new CalculatorService();
            decimal expectedValue = result;

            //process
            decimal resultValue = calculator.Add(n1, n2);

            //asserts
            Assert.IsTrue(expectedValue == resultValue);
        }

        [TestCase(2, 2, 0)]
        [TestCase(1, 2, -1)]
        [TestCase(2, 4, -2)]
        [TestCase(-2, 2, -4)]
        public void Testing_Subtract_TwoNumbersAreSubtracted(decimal n1, decimal n2, decimal result)
        {
            //arrange
            var calculator = new CalculatorService();
            decimal expectedValue = result;

            //process
            decimal resultValue = calculator.Subtract(n1, n2);

            //asserts
            Assert.IsTrue(expectedValue == resultValue);
        }

        [TestCase(2, 2, 1)]
        [TestCase(3, 2, 1.5d)]
        [TestCase(4, 2, 2)]
        public void Testing_Divide_TwoNumbersAreDivided(decimal n1, decimal n2, decimal result)
        {
            //arrange
            var calculator = new CalculatorService();
            decimal expectedValue = result;

            //process
            decimal resultValue = calculator.Divide(n1, n2);

            //asserts
            Assert.IsTrue(expectedValue == resultValue);
        }

        [TestCase(2, -2, 1)]
        [TestCase(3, 0, 1)]
        public void Testing_Divide_When_Number2IsLessOrEqualZero_Then_ThrowsException(decimal n1, decimal n2, decimal result)
        {
            //arrange
            var calculator = new CalculatorService();
            decimal expectedValue = result;

            //process
            Action division = () => calculator.Divide(n1, n2);

            //asserts
            Assert.Throws<Exception>(division.Invoke);
        }

        [TestCase(2, 2, 4)]
        [TestCase(1, 2, 2)]
        [TestCase(2, 4, 8)]
        [TestCase(-2, 2, -4)]
        public void Testing_Multiply_TwoNumbersAreMultiplied(decimal n1, decimal n2, decimal result)
        {
            //arrange
            var calculator = new CalculatorService();
            decimal expectedValue = result;

            //process
            decimal resultValue = calculator.Multiply(n1, n2);

            //asserts
            Assert.IsTrue(expectedValue == resultValue);
        }
    }
}