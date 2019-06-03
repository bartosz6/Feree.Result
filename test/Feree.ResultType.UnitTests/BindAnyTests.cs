using System.Threading.Tasks;
using Feree.ResultType.Factories;
using Feree.ResultType.Operations;
using Shouldly;
using Xunit;

namespace Feree.ResultType.UnitTests
{
    public class BindAnyTests
    {
        [Fact]
        public void BindAny_OnSuccess_GivenObject_ReturnsSuccess()
        {
            var success = ResultFactory.CreateSuccess(3);
            
            var result = success.BindAny(a => a + 3);

            result.ShouldBeSuccess();
            result.Payload().ShouldBe(6);
        }
        
        [Fact]
        public void BindAny_OnSuccess_GivenObject_WhenPayloadIgnored_ReturnsSuccess()
        {
            var success = ResultFactory.CreateSuccess(3);
            
            var result = success.BindAny(() => 4);

            result.ShouldBeSuccess();
            result.Payload().ShouldBe(4);
        }
        
        [Fact]
        public void BindAny_OnFailure_GivenObject_ReturnsFailure()
        {
            var failure = ResultFactory.CreateFailure<int>("serious error");
            
            var result = failure.BindAny(a => a + 3);

            result.ShouldBeFailure();
            result.Error().Message.ShouldBe("serious error");
        }
        
        [Fact]
        public void BindAny_OnFailure_GivenObject_WhenPayloadIgnored_ReturnsFailure()
        {
            var failure = ResultFactory.CreateFailure<int>("serious error");
            
            var result = failure.BindAny(() => 4);

            result.ShouldBeFailure();
            result.Error().Message.ShouldBe("serious error");
        }
        
        [Fact]
        public async Task BindAnyAsync_OnSuccess_GivenTask_ReturnsSuccessAsync()
        {
            var success = ResultFactory.CreateSuccess(2);
            
            var result = await success.BindAnyAsync(a => Task.FromResult(a + 3));

            result.ShouldBeSuccess();
            result.Payload().ShouldBe(5);
        }
        
        [Fact]
        public async Task BindAnyAsync_OnFailure_GivenTask_ReturnsFailureAsync()
        {
            var failure = ResultFactory.CreateFailure<int>("serious error");
            
            var result = await failure.BindAnyAsync(a => Task.FromResult(a + 3));

            result.ShouldBeFailure();
            result.Error().Message.ShouldBe("serious error");
        }
        
        [Fact]
        public async Task BindAnyAsync_OnSuccess_GivenTask_WhenPayloadIsIgnored_ReturnsSuccessAsync()
        {
            var success = ResultFactory.CreateSuccess(2);
            
            var result = await success.BindAnyAsync(() => Task.FromResult(5));

            result.ShouldBeSuccess();
            result.Payload().ShouldBe(5);
        }
        
        [Fact]
        public async Task BindAnyAsync_OnFailure_GivenTask_WhenPayloadIsIgnored_ReturnsFailureAsync()
        {
            var failure = ResultFactory.CreateFailure<int>("serious error");
            
            var result = await failure.BindAnyAsync(() => Task.FromResult(5));

            result.ShouldBeFailure();
            result.Error().Message.ShouldBe("serious error");
        }
        
        [Fact]
        public async Task BindAnyAsync_OnSuccessAsync_GivenTask_ReturnsSuccessAsync()
        {
            var success = ResultFactory.CreateSuccessAsync(2);
            
            var result = await success.BindAnyAsync(a => Task.FromResult(a + 3));

            result.ShouldBeSuccess();
            result.Payload().ShouldBe(5);
        }
        
        [Fact]
        public async Task BindAnyAsync_OnFailureAsync_GivenTask_ReturnsFailureAsync()
        {
            var failure = ResultFactory.CreateFailureAsync<int>("serious error");
            
            var result = await failure.BindAnyAsync(a => Task.FromResult(a + 3));

            result.ShouldBeFailure();
            result.Error().Message.ShouldBe("serious error");
        }
        
        [Fact]
        public async Task BindAnyAsync_OnSuccessAsync_GivenTask_WhenPayloadIsIgnored_ReturnsSuccessAsync()
        {
            var success = ResultFactory.CreateSuccessAsync(2);
            
            var result = await success.BindAnyAsync(() => Task.FromResult(5));

            result.ShouldBeSuccess();
            result.Payload().ShouldBe(5);
        }
        
        [Fact]
        public async Task BindAnyAsync_OnFailureAsync_GivenTask_WhenPayloadIsIgnored_ReturnsFailureAsync()
        {
            var failure = ResultFactory.CreateFailureAsync<int>("serious error");
            
            var result = await failure.BindAnyAsync(() => Task.FromResult(5));

            result.ShouldBeFailure();
            result.Error().Message.ShouldBe("serious error");
        }
        
        [Fact]
        public async Task BindAnyAsync_OnSuccessAsync_GivenValue_ReturnsSuccessAsync()
        {
            var success = ResultFactory.CreateSuccessAsync(2);
            
            var result = await success.BindAnyAsync(a => a + 3);

            result.ShouldBeSuccess();
            result.Payload().ShouldBe(5);
        }
        
        [Fact]
        public async Task BindAnyAsync_OnFailureAsync_GivenValue_ReturnsFailureAsync()
        {
            var failure = ResultFactory.CreateFailureAsync<int>("serious error");
            
            var result = await failure.BindAnyAsync(a => a + 3);

            result.ShouldBeFailure();
            result.Error().Message.ShouldBe("serious error");
        }
        
        [Fact]
        public async Task BindAnyAsync_OnSuccessAsync_GivenValue_WhenPayloadIsIgnored_ReturnsSuccessAsync()
        {
            var success = ResultFactory.CreateSuccessAsync(2);
            
            var result = await success.BindAnyAsync(() => 5);

            result.ShouldBeSuccess();
            result.Payload().ShouldBe(5);
        }
        
        [Fact]
        public async Task BindAnyAsync_OnFailureAsync_GivenValue_WhenPayloadIsIgnored_ReturnsFailureAsync()
        {
            var failure = ResultFactory.CreateFailureAsync<int>("serious error");
            
            var result = await failure.BindAnyAsync(() => 3);

            result.ShouldBeFailure();
            result.Error().Message.ShouldBe("serious error");
        }
    }
}