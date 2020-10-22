using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Feree.ResultType.Results
{
    public static class MapExtensions
    {
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TOut Map<TIn, TOut>(this IResult<TIn> result, Func<TIn, TOut> onSuccess, Func<IError, TOut> onFailure) =>
            result switch
            {
                Success<TIn> success => onSuccess(success.Payload),
                Failure failure => onFailure(failure.Error),
                _ => throw new InvalidOperationException("unknown result type")
            };

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<TOut> MapAsync<TIn, TOut>(this Task<IResult<TIn>> result, Func<TIn, Task<TOut>> onSuccess,
            Func<IError, Task<TOut>> onFailure) =>
            await result switch
            {
                Success<TIn> success => await onSuccess(success.Payload),
                Failure failure => await onFailure(failure.Error),
                _ => throw new InvalidOperationException("unknown result type")
            };

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<TOut> MapAsync<TIn, TOut>(this Task<IResult<TIn>> result, Func<TIn, TOut> onSuccess, Func<IError, TOut> onFailure) =>
            await result switch
            {
                Success<TIn> success => onSuccess(success.Payload),
                Failure failure => onFailure(failure.Error),
                _ => throw new InvalidOperationException("unknown result type")
            };
    }
}