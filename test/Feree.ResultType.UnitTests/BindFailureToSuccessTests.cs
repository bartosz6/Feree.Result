using System.Threading.Tasks;
using Feree.ResultType.Factories;
using Feree.ResultType.Results;
using Shouldly;
using Xunit;

namespace Feree.ResultType.UnitTests
{
    public class BindSuccessToFailureTests
    {
        [Fact]
        public void Bind_ReturnsFailure()
        {
            var success = ResultFactory.CreateSuccess(1);
            var next = ResultFactory.CreateFailure("some serious message");
            var result = success.Bind(a => next);

            result.ShouldBeFailure();
            result.Error().Message.ShouldBe("some serious message");
        }

        [Fact]
        public void Bind_WhenResultIgnored_ReturnsFailure()
        {
            var success = ResultFactory.CreateSuccess(1);
            var next = ResultFactory.CreateFailure("some serious message");

            var result = success.Bind(() => next);

            result.ShouldBeFailure();
            result.Error().Message.ShouldBe("some serious message");
        }

        [Fact]
        public async Task BindAsync_WhenNextIsAsync_ReturnsFailureAsync()
        {
            var success = ResultFactory.CreateSuccess(1);
            var next = ResultFactory.CreateFailureAsync("some serious message");

            var result = success.BindAsync(a => next);

            await result.ShouldBeFailure();
            (await result.Error()).Message.ShouldBe("some serious message");
        }

        [Fact]
        public async Task BindAsync_WhenNextIsAsync_WhenResultIgnored_ReturnsFailureAsync()
        {
            var success = ResultFactory.CreateSuccess(1);
            var next = ResultFactory.CreateFailureAsync("some serious message");

            var result = success.BindAsync(() => next);

            await result.ShouldBeFailure();
            (await result.Error()).Message.ShouldBe("some serious message");
        }

        [Fact]
        public async Task BindAsync_WhenPrevIsAsync_ReturnsFailureAsync()
        {
            var success = ResultFactory.CreateSuccessAsync(1);
            var next = ResultFactory.CreateFailure("some serious message");

            var result = success.BindAsync(a => next);

            await result.ShouldBeFailure();
            (await result.Error()).Message.ShouldBe("some serious message");
        }

        [Fact]
        public async Task BindAsync_WhenPrevIsAsync_WhenResultIgnored_ReturnsFailureAsync()
        {
            var success = ResultFactory.CreateSuccessAsync(1);
            var next = ResultFactory.CreateFailure("some serious message");

            var result = success.BindAsync(() => next);

            await result.ShouldBeFailure();
            (await result.Error()).Message.ShouldBe("some serious message");
        }

        [Fact]
        public async Task BindAsync_WhenBothAreAsync_ReturnsFailureAsync()
        {
            var success = ResultFactory.CreateSuccessAsync(1);
            var next = ResultFactory.CreateFailureAsync("some serious message");

            var result = success.BindAsync(a => next);

            await result.ShouldBeFailure();
            (await result.Error()).Message.ShouldBe("some serious message");
        }

        [Fact]
        public async Task BindAsync_WhenBothAreAsync_WhenResultIgnored_ReturnsFailureAsync()
        {
            var success = ResultFactory.CreateSuccessAsync(1);
            var next = ResultFactory.CreateFailureAsync("some serious message");

            var result = success.BindAsync(() => next);

            await result.ShouldBeFailure();
            (await result.Error()).Message.ShouldBe("some serious message");
        }
    }
}