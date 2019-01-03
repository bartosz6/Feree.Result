using System;
using System.Threading.Tasks;

namespace Feree.ResultType.Results
{
    public class Success<T> : Success, IResult<T>
    {
        protected internal Success(T payload)
        {
            if (payload == null) throw new ArgumentNullException(nameof(payload));

            Payload = payload;
        }

        public T Payload { get; }

        public IResult<TNext> Bind<TNext>(Func<T, IResult<TNext>> next) => next(Payload);

        public Task<IResult<TNext>> BindAsync<TNext>(Func<T, Task<IResult<TNext>>> next) => next(Payload);
    }

    public abstract class Success : IResult<Unit>
    {
        protected internal Success()
        {
        }

        public IResult<TNext> Bind<TNext>(Func<Unit, IResult<TNext>> next) => next(new Unit());

        public IResult<TNext> Bind<TNext>(Func<IResult<TNext>> next) => next();

        public Task<IResult<TNext>> BindAsync<TNext>(Func<Unit, Task<IResult<TNext>>> next) => next(new Unit());

        public Task<IResult<TNext>> BindAsync<TNext>(Func<Task<IResult<TNext>>> next) => next();
    }
}