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

        [Test(ExpectedResult = 0)]
        public int WhiteSpaceStringShouldReturnZero()
        {
            return Calculator.Add("  ");
        }

        [Test]
        [TestCase("1", ExpectedResult = 1)]
        [TestCase("10", ExpectedResult = 10)]
        public int OneNumberSouldReturnSameNumber(string value)
        {
            return Calculator.Add(value);
        }

        [Test]
        [TestCase("1,2", ExpectedResult = 3)]
        [TestCase("1,10", ExpectedResult = 11)]
        public int TwoNumberCommaSeparatedSouldReturnSum(string values)
        {
            return Calculator.Add(values);
        }

        [Test]
        [TestCase("1,", ExpectedResult = 1)]
        public int CommaSeparatedWithNoValueShouldReturnValidValue (string values)
        {
            return Calculator.Add(values);
        }

        [Test]
        [TestCase("1,2,3,4,5", ExpectedResult = 15)]
        [TestCase("1,10,10,10,10,10,10,10,10", ExpectedResult = 81)]
        public int UnlimitedNumbersCommaSeparatedSouldReturnSum(string values)
        {
            return Calculator.Add(values);
        }
    }
}