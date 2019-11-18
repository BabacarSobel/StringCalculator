using NUnit.Framework;
using System;

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

        [Test]
        [TestCase("1\n2,3", ExpectedResult =6)]
        [TestCase("1\n2\n3", ExpectedResult = 6)]
        public int NewLineCanBeUsedAsCommaForOperation(string values)
        {
            return Calculator.Add(values);
        }

        [Test]
        [TestCase("1,\n")]
        [TestCase("1,              \n")]
        public void EmptyAfterNewLineShouldFail(string values)
        {
            try
            {
                Calculator.Add(values);
            }catch(Exception e)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        [TestCase("//;\n1;2",ExpectedResult = 3)]
        [TestCase("//ajouter\n1ajouter2ajouter3\n 4", ExpectedResult = 10)]
        public int NewDelimiterCanBeDefinedInFirstLine(string values)
        {
            return Calculator.Add(values);
        }
    }
}