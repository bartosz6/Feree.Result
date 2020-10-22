using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Feree.ResultType.Results
{
    public class Success<T> : Success, IResult<T>
    {
        [DebuggerHidden]
        protected internal Success(T payload)
        {
            if (payload == null) throw new ArgumentNullException(nameof(payload));

            Payload = payload;
        }

        public T Payload { get; }

        [DebuggerHidden]
        public IResult<TNext> Bind<TNext>(Func<T, IResult<TNext>> next) => next(Payload);

        [DebuggerHidden]
        public Task<IResult<TNext>> BindAsync<TNext>(Func<T, Task<IResult<TNext>>> next) => next(Payload);

        [DebuggerHidden]
        public static implicit operator T(Success<T> success) => success.Payload;
    }

    public abstract class Success : IResult<Unit>
    {
        [DebuggerHidden]
        protected internal Success()
        {
        }

        [DebuggerHidden]
        public IResult<TNext> Bind<TNext>(Func<Unit, IResult<TNext>> next) => next(new Unit());

        [DebuggerHidden]
        public IResult<TNext> Bind<TNext>(Func<IResult<TNext>> next) => next();

        [DebuggerHidden]
        public Task<IResult<TNext>> BindAsync<TNext>(Func<Unit, Task<IResult<TNext>>> next) => next(new Unit());

        [DebuggerHidden]
        public Task<IResult<TNext>> BindAsync<TNext>(Func<Task<IResult<TNext>>> next) => next();
    }
}