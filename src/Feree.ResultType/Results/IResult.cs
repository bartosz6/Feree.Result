using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Feree.ResultType.Results
{
    public interface IResult
    {
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        IResult<TNext> Bind<TNext>(Func<IResult<TNext>> next);
        
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        Task<IResult<TNext>> BindAsync<TNext>(Func<Task<IResult<TNext>>> next);
    }

    public interface IResult<out T> : IResult
    {
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        IResult<TNext> Bind<TNext>(Func<T, IResult<TNext>> next);
        
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        Task<IResult<TNext>> BindAsync<TNext>(Func<T, Task<IResult<TNext>>> next);
    }
}