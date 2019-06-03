using System.Threading.Tasks;
using Feree.ResultType.Factories;
using Feree.ResultType.Results;
using Shouldly;
using Xunit;

namespace Feree.ResultType.UnitTests
{
    public class BindSuccessToSuccessTests
    {
        [Fact]
        public void Bind_ReturnsSuccess()
        {
            var success = ResultFactory.CreateSuccess(1);
            var next = ResultFactory.CreateSuccess(2);

            var result = success.Bind(a => next);

            result.ShouldBeSuccess();
            result.Payload().ShouldBe(2);
        }

        [Fact]
        public void Bind_WhenResultIgnored_ReturnsSuccess()
        {
            var success = ResultFactory.CreateSuccess(1);
            var next = ResultFactory.CreateSuccess(2);

            var result = success.Bind(() => next);

            result.ShouldBeSuccess();
            result.Payload().ShouldBe(2);
        }

        [Fact]
        public async Task BindAsync_WhenNextIsAsync_ReturnsSuccessAsync()
        {
            var success = ResultFactory.CreateSuccess(1);
            var next = Task.FromResult(ResultFactory.CreateSuccess(2));

            var result = success.BindAsync(a => next);

            await result.ShouldBeSuccess();
            (await result.Payload()).ShouldBe(2);
        }

        [Fact]
        public async Task BindAsync_WhenNextIsAsync_WhenResultIgnored_ReturnsSuccessAsync()
        {
            var success = ResultFactory.CreateSuccess(1);
            var next = Task.FromResult(ResultFactory.CreateSuccess(2));

            var result = success.BindAsync(() => next);

            await result.ShouldBeSuccess();
            (await result.Payload()).ShouldBe(2);
        }

        [Fact]
        public async Task BindAsync_WhenPrevIsAsync_ReturnsSuccessAsync()
        {
            var success = Task.FromResult(ResultFactory.CreateSuccess(1));
            var next = ResultFactory.CreateSuccess(2);

            var result = success.BindAsync(a => next);

            await result.ShouldBeSuccess();
            (await result.Payload()).ShouldBe(2);
        }

        [Fact]
        public async Task BindAsync_WhenPrevIsAsync_WhenResultIgnored_ReturnsSuccessAsync()
        {
            var success = Task.FromResult(ResultFactory.CreateSuccess(1));
            var next = ResultFactory.CreateSuccess(2);

            var result = success.BindAsync(() => next);

            await result.ShouldBeSuccess();
            (await result.Payload()).ShouldBe(2);
        }

        [Fact]
        public async Task BindAsync_WhenBothAreAsync_ReturnsSuccessAsync()
        {
            var success = Task.FromResult(ResultFactory.CreateSuccess(1));
            var next = Task.FromResult(ResultFactory.CreateSuccess(2));

            var result = success.BindAsync(a => next);

            await result.ShouldBeSuccess();
            (await result.Payload()).ShouldBe(2);
        }

        [Fact]
        public async Task BindAsync_WhenBothAreAsync_WhenResultIgnored_ReturnsSuccessAsync()
        {
            var success = Task.FromResult(ResultFactory.CreateSuccess(1));
            var next = Task.FromResult(ResultFactory.CreateSuccess(2));

            var result = success.BindAsync(() => next);

            await result.ShouldBeSuccess();
            (await result.Payload()).ShouldBe(2);
        }
    }
}