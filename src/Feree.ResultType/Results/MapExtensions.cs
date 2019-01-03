using System;
using System.Threading.Tasks;
using Feree.ResultType.Errors;

namespace Feree.ResultType.Results
{
    public static class MapExtensions
    {
        public static TOut Map<TIn, TOut>(this IResult<TIn> result, Func<TIn, TOut> onSuccess, Func<IError, TOut> onFailure)
        {
            switch (result)
            {
                case Success<TIn> success:
                    return onSuccess(success.Payload);
                case Failure failure:
                    return onFailure(failure.Error);
                default:
                    throw new InvalidOperationException("unknown result type");
            }
        }
        
        public static async Task<TOut> MapAsync<TIn, TOut>(this Task<IResult<TIn>> result, Func<TIn, Task<TOut>> onSuccess, Func<IError, Task<TOut>> onFailure)
        {
            switch (await result)
            {
                case Success<TIn> success:
                    return await onSuccess(success.Payload);
                case Failure failure:
                    return await onFailure(failure.Error);
                default:
                    throw new InvalidOperationException("unknown result type");
            }
        }
        
        public static async Task<TOut> MapAsync<TIn, TOut>(this Task<IResult<TIn>> result, Func<TIn, TOut> onSuccess, Func<IError, TOut> onFailure)
        {
            switch (await result)
            {
                case Success<TIn> success:
                    return onSuccess(success.Payload);
                case Failure failure:
                    return onFailure(failure.Error);
                default:
                    throw new InvalidOperationException("unknown result type");
            }
        }
    }
}