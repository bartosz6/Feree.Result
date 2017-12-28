using Feree.ResultType;

namespace Feree.ResultType.Tests.Helpers
{
    internal static class Casters
    {
        internal static Success<T> AsSuccess<T>(this IResult<T> result) => (Success<T>) result;
        
        internal static Failure<T> AsFailure<T>(this IResult<T> result) => (Failure<T>) result;
    }
}