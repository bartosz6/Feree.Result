using Feree.ResultType.Factories;
using Feree.ResultType.Results;
using Xunit;
// ReSharper disable IsExpressionAlwaysTrue

namespace Feree.ResultType.UnitTests
{
    public class PatternMatchingTests
    {
        [Fact]
        public void Is_GivenSuccessOfTAndSuccess_ReturnsTrue()
        {
            var success = ResultFactory.CreateSuccess(5);
            
            Assert.True(success is IResult);
            Assert.True(success is IResult<int>);
            Assert.True(success is Success);
            Assert.True(success is Success<int>);
        }

        [Fact]
        public void Is_GivenSuccessOfTAndFailure_ReturnsTrue()
        {
            var success = ResultFactory.CreateSuccess(5);
            
            Assert.True(success is IResult);
            Assert.True(success is IResult<int>);
            Assert.False(success is Failure);
            Assert.False(success is Failure<int>);
        }

        [Fact]
        public void Is_GivenFailureOfTAndFailure_ReturnsTrue()
        {
            var failure = ResultFactory.CreateFailure<int>("");
            
            Assert.True(failure is IResult);
            Assert.True(failure is IResult<int>);
            Assert.True(failure is Failure);
            Assert.True(failure is Failure<int>);
        }

        [Fact]
        public void Is_GivenFailureOfTAndSuccess_ReturnsFalse()
        {
            var failure = ResultFactory.CreateFailure<int>("");
            
            Assert.True(failure is IResult);
            Assert.True(failure is IResult<int>);
            Assert.False(failure is Success);
            Assert.False(failure is Success<int>);
        }
    }
}