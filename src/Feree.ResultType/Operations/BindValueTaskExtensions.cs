using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Feree.ResultType.Factories;
using Feree.ResultType.Results;

namespace Feree.ResultType.Operations
{
    public static class BindValueTaskExtensions
    {
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<IResult<TOut>> BindAsync<TIn, TOut>(this ValueTask<IResult<TIn>> result, Func<TIn, Task<IResult<TOut>>> next) =>
            result.IsCompletedSuccessfully
                ? result.Result.BindAsync(next)
                : result.AsTask().BindAsync(next);

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<IResult<TOut>> BindAsync<TIn, TOut>(this IResult<TIn> result, Func<TIn, ValueTask<IResult<TOut>>> next) =>
            result.Map(next, e => new ValueTask<IResult<TOut>>(ResultFactory.CreateFailure<TOut>(e)));

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<IResult<TOut>> BindAsync<TIn, TOut>(this Task<IResult<TIn>> result, Func<TIn, ValueTask<IResult<TOut>>> next) =>
            (new ValueTask<IResult<TIn>>(result)).BindAsync(next);

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<IResult<TOut>> BindAsync<TIn, TOut>(this ValueTask<IResult<TIn>> result, Func<TIn, IResult<TOut>> next) =>
            result.IsCompletedSuccessfully
                ? new ValueTask<IResult<TOut>>(result.Result.Bind(next))
                : new ValueTask<IResult<TOut>>(result.AsTask().BindAsync(next));

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<IResult<TOut>> BindAsync<TIn, TOut>(this ValueTask<IResult<TIn>> result, Func<TIn, ValueTask<IResult<TOut>>> next) =>
            result.IsCompletedSuccessfully
                ? result.Result.BindAsync(next)
                : new ValueTask<IResult<TOut>>(result.AsTask().BindAsync(x => next(x).AsTask()));
    }
}