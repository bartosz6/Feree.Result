using Feree.ResultType.Factories;
using Feree.ResultType.Results;
using Xunit;

namespace Feree.ResultType.UnitTests
{
    public class FailureOfTTests
    {
        [Fact]
        public void Bind_GivenNextWithNoArg_ReturnsFailureWithNewType()
        {
            var failure = ResultFactory.CreateFailure<string>("error") as Failure<string>;

            var result = failure.Bind(() => ResultFactory.CreateSuccess(1));
            
            Assert.True(result is Failure);
            Assert.True(result is Failure<int>);
            Assert.True(result is Failure<int> f && f.Error == failure.Error);
        }
        
        [Fact]
        public void Bind_GivenNextWithArg_ReturnsFailureWithNewType()
        {
            var failure = ResultFactory.CreateFailure<string>("error") as Failure<string>;

            var result = failure.Bind(unit => ResultFactory.CreateSuccess(1));
            
            Assert.True(result is Failure);
            Assert.True(result is Failure<int>);
            Assert.True(result is Failure<int> f && f.Error == failure.Error);
        }
    }
}