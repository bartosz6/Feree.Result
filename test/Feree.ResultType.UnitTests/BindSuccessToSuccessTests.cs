using System.Threading.Tasks;
using Feree.ResultType.Factories;
using Feree.ResultType.Results;
using Shouldly;
using Xunit;

namespace Feree.ResultType.UnitTests
{
    public class BindTests
    {
        [Fact]
        public void Bind_OnSuccess_GivenSuccess_ReturnsSuccess()
        {
            var success = ResultFactory.CreateSuccess(1);
            var next = ResultFactory.CreateSuccess(2);

            var result = success.Bind(a => next);

            result.ShouldBeSuccess();
            result.Payload().ShouldBe(2);
        }

        [Fact]
        public void Bind_OnSuccess_WhenResultIgnored_GivenSuccess_ReturnsSuccess()
        {
            var success = ResultFactory.CreateSuccess(1);
            var next = ResultFactory.CreateSuccess(2);

            var result = success.Bind(() => next);

            result.ShouldBeSuccess();
            result.Payload().ShouldBe(2);
        }

        [Fact]
        public async Task BindAsync_OnSuccess_GivenSuccessAsync_ReturnsSuccessAsync()
        {
            var success = ResultFactory.CreateSuccess(1);
            var next = Task.FromResult(ResultFactory.CreateSuccess(2));

            var result = success.BindAsync(a => next);

            await result.ShouldBeSuccess();
            (await result.Payload()).ShouldBe(2);
        }

        [Fact]
        public async Task BindAsync_OnSuccess_WhenResultIgnored_GivenSuccessAsync_ReturnsSuccessAsync()
        {
            var success = ResultFactory.CreateSuccess(1);
            var next = Task.FromResult(ResultFactory.CreateSuccess(2));

            var result = success.BindAsync(() => next);

            await result.ShouldBeSuccess();
            (await result.Payload()).ShouldBe(2);
        }

        [Fact]
        public async Task BindAsync_OnSuccessAsync_GivenSuccessAsync_ReturnsSuccessAsync()
        {
            var success = Task.FromResult(ResultFactory.CreateSuccess(1));
            var next = Task.FromResult(ResultFactory.CreateSuccess(2));

            var result = success.BindAsync(a => next);

            await result.ShouldBeSuccess();
            (await result.Payload()).ShouldBe(2);
        }

        [Fact]
        public async Task BindAsync_OnSuccessAsync_WhenResultIgnored_GivenSuccessAsync_ReturnsSuccessAsync()
        {
            var success = Task.FromResult(ResultFactory.CreateSuccess(1));
            var next = Task.FromResult(ResultFactory.CreateSuccess(2));

            var result = success.BindAsync(() => next);

            await result.ShouldBeSuccess();
            (await result.Payload()).ShouldBe(2);
        }
    }

    public static class ResultAssertExtensions
    {
        public static void ShouldBeSuccess<T>(this IResult<T> result) => result.ShouldBeOfType(typeof(Success<T>));
        public static void ShouldBeFailure<T>(this IResult<T> result) => result.ShouldBeOfType(typeof(Failure<T>));
        public static async Task ShouldBeSuccess<T>(this Task<IResult<T>> result) => (await result).ShouldBeOfType(typeof(Success<T>));
        public static async Task ShouldBeFailure<T>(this Task<IResult<T>> result) => (await result).ShouldBeOfType(typeof(Failure<T>));

        public static async Task<T> Payload<T>(this Task<IResult<T>> result)
        {
            var awaited = await result;
            awaited.ShouldBeOfType(typeof(Success<T>));
            var success = (Success<T>) awaited;
            return success.Payload;
        }

        public static T Payload<T>(this IResult<T> result)
        {
            result.ShouldBeOfType(typeof(Success<T>));
            var success = (Success<T>) result;
            return success.Payload;
        }
    }
}