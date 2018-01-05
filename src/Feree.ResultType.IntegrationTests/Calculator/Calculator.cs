using Feree.ResultType;

namespace Feree.ResultType.IntegrationTests.Calculator
{
    public class Calculator
    {
        private Calculator()
        {
        }

        public static IResult<Calculator> Create() => ResultFactory.CreateSuccess(new Calculator());

        public IResult<double> Add(double augend, double addend) => ResultFactory.CreateSuccess(augend + addend);

        public IResult<double> Substract(double minuend, double subtrahend) =>
            ResultFactory.CreateSuccess(minuend - subtrahend);

        public IResult<double> Multiply(double multiplicand, double multiplier) =>
            ResultFactory.CreateSuccess(multiplicand * multiplier);

        public IResult<double> Divide(double dividend, double divisor) => divisor == 0
            ? ResultFactory.CreateFailure<double>("division by zero")
            : ResultFactory.CreateSuccess(dividend / divisor);

        public IResult<double> Exp(double @base, int exponent)
        {
            if (exponent == 0) return ResultFactory.CreateSuccess(1.0);
            if (exponent > 0) return Exp(@base, exponent - 1).Bind(r => Multiply(@base, r));
            if (exponent < 0) return Exp(@base, -1 * exponent).Bind(result => Divide(1.0, result));
            return ResultFactory.CreateFailure<double>("error");
        }
    }
}