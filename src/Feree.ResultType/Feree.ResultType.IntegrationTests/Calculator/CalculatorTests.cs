using Feree.ResultType;
using NUnit.Framework;

namespace Feree.ResultType.IntegrationTests.Calculator
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            if (Calculator.Create() is Success<Calculator> calculator)
                _calculator = calculator.Payload;
        }

        [TestCase(2, 2, 4)]
        [TestCase(2, 3, 8)]
        [TestCase(3, 2, 9)]
        [TestCase(2, 0, 1)]
        [TestCase(0, 0, 1)]
        [TestCase(2, -1, 0.5)]
        [TestCase(2, -2, 0.25)]
        public void Exp_Cases(double @base, int exponent, double expected)
        {
            var result = _calculator.Exp(@base, exponent);
            
            Assert.That(((Success<double>)result).Payload, Is.EqualTo(expected));
        }
    }
}