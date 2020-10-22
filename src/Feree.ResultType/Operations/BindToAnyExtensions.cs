using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Feree.ResultType.Converters;
using Feree.ResultType.Results;

namespace Feree.ResultType.Operations
{
    public static class BindToAnyExtensions
    {
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IResult<TNext> BindAny<TPrev, TNext>(this IResult<TPrev> prev, Func<TNext> next) =>
            prev.Bind(() => next().AsResult());

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<IResult<TNext>> BindAnyAsync<TPrev, TNext>(this Task<IResult<TPrev>> prev, Func<TNext> next) =>
            prev.BindAsync(() => next().AsResult());

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<IResult<TNext>> BindAnyAsync<TPrev, TNext>(this Task<IResult<TPrev>> prev, Func<Task<TNext>> next) =>
            prev.BindAsync(() => next().AsResultAsync());

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<IResult<TNext>> BindAnyAsync<TPrev, TNext>(this IResult<TPrev> prev, Func<Task<TNext>> next) =>
            prev.BindAsync(() => next().AsResultAsync());

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IResult<TNext> BindAny<TPrev, TNext>(this IResult<TPrev> prev, Func<TPrev, TNext> next) =>
            prev.Bind(a => next(a).AsResult());

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<IResult<TNext>> BindAnyAsync<TPrev, TNext>(this Task<IResult<TPrev>> prev, Func<TPrev, TNext> next) =>
            prev.BindAsync(a => next(a).AsResult());

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<IResult<TNext>> BindAnyAsync<TPrev, TNext>(this Task<IResult<TPrev>> prev, Func<TPrev, Task<TNext>> next) =>
            prev.BindAsync(a => next(a).AsResultAsync());

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<IResult<TNext>> BindAnyAsync<TPrev, TNext>(this IResult<TPrev> prev, Func<TPrev, Task<TNext>> next) =>
            prev.BindAsync(a => next(a).AsResultAsync());
    }
}