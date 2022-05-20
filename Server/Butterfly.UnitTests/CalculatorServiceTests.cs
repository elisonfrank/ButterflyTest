using Butterfly.Services.Services;

namespace Butterfly.UnitTests
{
    public class CalculatorServiceTests
    {
        [TestCase(2, 2, 4)]
        [TestCase(1, 2, 3)]
        [TestCase(2, 4, 6)]
        [TestCase(-2, 2, 0)]
        public void Testing_Add_TwoNumbersAreAdded(float n1, float n2, float result)
        {
            //arrange
            var calculator = new CalculatorService();
            float expectedValue = result;

            //process
            float resultValue = calculator.Add(n1, n2);

            //asserts
            Assert.IsTrue(expectedValue == resultValue);
        }

        [TestCase(2, 2, 0)]
        [TestCase(1, 2, -1)]
        [TestCase(2, 4, -2)]
        [TestCase(-2, 2, -4)]
        public void Testing_Subtract_TwoNumbersAreSubtracted(float n1, float n2, float result)
        {
            //arrange
            var calculator = new CalculatorService();
            float expectedValue = result;

            //process
            float resultValue = calculator.Subtract(n1, n2);

            //asserts
            Assert.IsTrue(expectedValue == resultValue);
        }

        [TestCase(2, 2, 1)]
        [TestCase(3, 2, 1.5f)]
        [TestCase(4, 2, 2)]
        public void Testing_Divide_TwoNumbersAreDivided(float n1, float n2, float result)
        {
            //arrange
            var calculator = new CalculatorService();
            float expectedValue = result;

            //process
            float resultValue = calculator.Divide(n1, n2);

            //asserts
            Assert.IsTrue(expectedValue == resultValue);
        }

        [TestCase(2, -2, 1)]
        [TestCase(3, 0, 1)]
        public void Testing_Divide_When_Number2IsLessOrEqualZero_Then_ThrowsException(float n1, float n2, float result)
        {
            //arrange
            var calculator = new CalculatorService();
            float expectedValue = result;

            //process
            Action division = () => calculator.Divide(n1, n2);

            //asserts
            Assert.Throws<Exception>(division.Invoke);
        }

        [TestCase(2, 2, 4)]
        [TestCase(1, 2, 2)]
        [TestCase(2, 4, 8)]
        [TestCase(-2, 2, -4)]
        public void Testing_Multiply_TwoNumbersAreMultiplied(float n1, float n2, float result)
        {
            //arrange
            var calculator = new CalculatorService();
            float expectedValue = result;

            //process
            float resultValue = calculator.Multiply(n1, n2);

            //asserts
            Assert.IsTrue(expectedValue == resultValue);
        }
    }
}