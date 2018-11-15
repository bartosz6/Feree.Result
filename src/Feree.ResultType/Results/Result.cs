using System;
using System.Threading.Tasks;
using Feree.ResultType.Errors;

namespace Feree.ResultType.Results
{
    public interface IResult
    {
        IResult<TNext> Bind<TNext>(Func<IResult<TNext>> next);
        Task<IResult<TNext>> BindAsync<TNext>(Func<Task<IResult<TNext>>> next);
    }

    public interface IResult<out T> : IResult
    {
        IResult<TNext> Bind<TNext>(Func<T, IResult<TNext>> next);
        Task<IResult<TNext>> BindAsync<TNext>(Func<T, Task<IResult<TNext>>> next);
    }

    public class Success<T> : Success, IResult<T>
    {
        protected internal Success(T payload)
        {
            if(payload == null) throw new ArgumentNullException(nameof(payload));

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

    public class Failure<T> : Failure, IResult<T>
    {
        protected internal Failure(IError error) : base(error) { }

        public IResult<TNext> Bind<TNext>(Func<T, IResult<TNext>> next) => 
            new Failure<TNext>(Error);

        public Task<IResult<TNext>> BindAsync<TNext>(Func<T, Task<IResult<TNext>>> next) => 
            Task.FromResult<IResult<TNext>>(new Failure<TNext>(Error));
    }

    public abstract class Failure : IResult<Unit>
    {
        public IError Error { get; }

        protected internal Failure(IError error) => Error = error ?? throw new ArgumentNullException(nameof(error));

        public IResult<TNext> Bind<TNext>(Func<Unit, IResult<TNext>> next) => new Failure<TNext>(Error);

        public IResult<TNext> Bind<TNext>(Func<IResult<TNext>> next) => new Failure<TNext>(Error);

        public Task<IResult<TNext>> BindAsync<TNext>(Func<Unit, Task<IResult<TNext>>> next) =>
            Task.FromResult<IResult<TNext>>(new Failure<TNext>(Error));

        public Task<IResult<TNext>> BindAsync<TNext>(Func<Task<IResult<TNext>>> next) =>
            Task.FromResult<IResult<TNext>>(new Failure<TNext>(Error));
    }
}