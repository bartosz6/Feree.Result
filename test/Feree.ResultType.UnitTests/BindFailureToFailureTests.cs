using System.Threading.Tasks;
using Feree.ResultType.Factories;
using Feree.ResultType.Results;
using Shouldly;
using Xunit;

namespace Feree.ResultType.UnitTests
{
    public class BindFailureToFailureTests
    {
        [Fact]
        public void Bind_ReturnsFailure()
        {
            var failure = ResultFactory.CreateFailure("some serious message");
            var next = ResultFactory.CreateFailure("next error");
            var result = failure.Bind(a => next);

            result.ShouldBeFailure();
            result.Error().Message.ShouldBe("some serious message");
        }

        [Fact]
        public void Bind_WhenResultIgnored_ReturnsFailure()
        {
            var failure =  ResultFactory.CreateFailure("some serious message");
            var next = ResultFactory.CreateFailure("next error");

            var result = failure.Bind(() => next);

            result.ShouldBeFailure();
            result.Error().Message.ShouldBe("some serious message");
        }

        [Fact]
        public async Task BindAsync_WhenNextIsAsync_ReturnsFailureAsync()
        {
            var failure = ResultFactory.CreateFailure("some serious message");
            var next =  ResultFactory.CreateFailureAsync("next error");

            var result = failure.BindAsync(a => next);

            await result.ShouldBeFailure();
            (await result.Error()).Message.ShouldBe("some serious message");
        }

        [Fact]
        public async Task BindAsync_WhenNextIsAsync_WhenResultIgnored_ReturnsFailureAsync()
        {
            var failure = ResultFactory.CreateFailure("some serious message");
            var next = ResultFactory.CreateFailureAsync("next error");

            var result = failure.BindAsync(() => next);

            await result.ShouldBeFailure();
            (await result.Error()).Message.ShouldBe("some serious message");
        }

        [Fact]
        public async Task BindAsync_WhenPrevIsAsync_ReturnsFailureAsync()
        {
            var failure = ResultFactory.CreateFailureAsync("some serious message"); 
            var next = ResultFactory.CreateFailure("next error");

            var result = failure.BindAsync(a => next);

            await result.ShouldBeFailure();
            (await result.Error()).Message.ShouldBe("some serious message");
        }

        [Fact]
        public async Task BindAsync_WhenPrevIsAsync_WhenResultIgnored_ReturnsFailureAsync()
        {
            var failure = ResultFactory.CreateFailureAsync("some serious message"); 
            var next = ResultFactory.CreateFailure("next error");

            var result = failure.BindAsync(() => next);

            await result.ShouldBeFailure();
            (await result.Error()).Message.ShouldBe("some serious message");
        }

        [Fact]
        public async Task BindAsync_WhenBothAreAsync_ReturnsFailureAsync()
        {
            var failure = ResultFactory.CreateFailureAsync("some serious message"); 
            var next = ResultFactory.CreateFailureAsync("next error");

            var result = failure.BindAsync(a => next);

            await result.ShouldBeFailure();
            (await result.Error()).Message.ShouldBe("some serious message");
        }

        [Fact]
        public async Task BindAsync_WhenBothAreAsync_WhenResultIgnored_ReturnsFailureAsync()
        {
            var failure = ResultFactory.CreateFailureAsync("some serious message"); 
            var next = ResultFactory.CreateFailureAsync("next error");

            var result = failure.BindAsync(() => next);

            await result.ShouldBeFailure();
            (await result.Error()).Message.ShouldBe("some serious message");
        }
    }
}