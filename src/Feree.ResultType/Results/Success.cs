using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Feree.ResultType.Results
{
    public record Success<T> : Success, IResult<T>
    {
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected internal Success(T payload)
        {
            if (payload == null) throw new ArgumentNullException(nameof(payload));

            Payload = payload;
        }

        public T Payload { get; }

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IResult<TNext> Bind<TNext>(Func<T, IResult<TNext>> next) => next(Payload);

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Task<IResult<TNext>> BindAsync<TNext>(Func<T, Task<IResult<TNext>>> next) => next(Payload);

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator T(Success<T> success) => success.Payload;
    }

    public abstract record Success : IResult<Unit>
    {
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected internal Success()
        {
        }

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IResult<TNext> Bind<TNext>(Func<Unit, IResult<TNext>> next) => next(new Unit());

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IResult<TNext> Bind<TNext>(Func<IResult<TNext>> next) => next();

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Task<IResult<TNext>> BindAsync<TNext>(Func<Unit, Task<IResult<TNext>>> next) => next(new Unit());

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Task<IResult<TNext>> BindAsync<TNext>(Func<Task<IResult<TNext>>> next) => next();
    }
}