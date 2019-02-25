using Feree.ResultType.Converters;
using Feree.ResultType.Factories;
using Feree.ResultType.Results;
using Shouldly;
using Xunit;

namespace Feree.ResultType.UnitTests
{
    public class ToUnitConvertersTests
    {
        [Fact]
        public void GivenSuccessOfString_ReturnSuccessOfUnit()
        {
            var resultOfString = ResultFactory.CreateSuccess("sup mate");

            var resultOfUnit = resultOfString.ToUnit();

            resultOfUnit.ShouldBeOfType(typeof(Success<Unit>));
        }
        
        [Fact]
        public void GivenFailureOfString_ReturnsFailureOfUnit()
        {
            var resultOfString = ResultFactory.CreateFailure<string>("sup mate");

            var resultOfUnit = resultOfString.ToUnit();

            resultOfUnit.ShouldBeOfType(typeof(Failure<Unit>));
        }
    }
}