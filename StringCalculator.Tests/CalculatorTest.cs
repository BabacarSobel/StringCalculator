using NUnit.Framework;

namespace StringCalculator.Tests
{
    public class CalculatorTest
    {
        Calculator Calculator;

        [SetUp]
        public void Setup()
        {
            Calculator = new Calculator();
        }

        [Test(ExpectedResult = 0)]
        public int EmptyStringShouldReturnZero()
        {
            return Calculator.Add(string.Empty);
        }
    }
}