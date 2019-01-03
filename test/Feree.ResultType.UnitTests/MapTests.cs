using System.Threading.Tasks;
using Feree.ResultType.Factories;
using Feree.ResultType.Results;
using Xunit;

namespace Feree.ResultType.UnitTests
{
    public class MapTests
    {
        [Fact]
        public void GivenSuccess_ReturnsOnSuccessDelegateResult()
        {
            var success = ResultFactory.CreateSuccess();

            var delegateResult = success.Map(unit => 1, error => 0);
            
            Assert.Equal(1, delegateResult);
        }
        
        [Fact]
        public async Task GivenAsyncSuccess_ReturnsOnSuccessDelegateResult()
        {
            var success = Task.FromResult(ResultFactory.CreateSuccess());

            var delegateResult = await success.MapAsync(unit => 1, error => 0);
            
            Assert.Equal(1, delegateResult);
        }
        
        [Fact]
        public void GivenFailure_ReturnsOnFailureDelegateResult()
        {
            var failure = ResultFactory.CreateFailure("error");

            var delegateResult = failure.Map(unit => 1, error => 0);
            
            Assert.Equal(0, delegateResult);
        }
        
        [Fact]
        public async Task GivenAsyncFailure_ReturnsOnFailureDelegateResult()
        {
            var failure = Task.FromResult(ResultFactory.CreateFailure("error"));

            var delegateResult = await failure.MapAsync(unit => 1, error => 0);
            
            Assert.Equal(0, delegateResult);
        }
    }
}