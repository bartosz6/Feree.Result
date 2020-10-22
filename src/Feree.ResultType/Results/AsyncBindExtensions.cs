using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Feree.ResultType.Results
{
    public static class AsyncBindExtensions
    {
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<IResult<TNext>> BindAsync<TPrev, TNext>(
            this Task<IResult<TPrev>> prev, Func<IResult<TNext>> next) =>
            (await prev).Bind(next);

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<IResult<TNext>> BindAsync<TPrev, TNext>(
            this Task<IResult<TPrev>> prev, Func<TPrev, IResult<TNext>> next) =>
            (await prev).Bind(next);

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<IResult<TNext>> BindAsync<TPrev, TNext>(
            this Task<IResult<TPrev>> prev, Func<Task<IResult<TNext>>> next) =>
            await (await prev).BindAsync(next);

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<IResult<TNext>> BindAsync<TPrev, TNext>(
            this Task<IResult<TPrev>> prev, Func<TPrev, Task<IResult<TNext>>> next) =>
            await (await prev).BindAsync(next);
    }
}