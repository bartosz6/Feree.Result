using System.Threading.Tasks;
using Feree.ResultType.Results;
using Shouldly;

namespace Feree.ResultType.UnitTests
{
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
        
        public static async Task<IError> Error<T>(this Task<IResult<T>> result)
        {
            var awaited = await result;
            awaited.ShouldBeOfType(typeof(Failure<T>));
            var success = (Failure<T>) awaited;
            return success.Error;
        }

        public static IError Error<T>(this IResult<T> result)
        {
            result.ShouldBeOfType(typeof(Failure<T>));
            var success = (Failure<T>) result;
            return success.Error;
        }
    }
}