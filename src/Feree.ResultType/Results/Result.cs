using System;
using System.Threading.Tasks;

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
        public Success(T payload)
        {
            if(payload == null) throw new ArgumentNullException(nameof(payload));

             Payload = payload; 
        }

        public T Payload { get; }

        public IResult<TNext> Bind<TNext>(Func<T, IResult<TNext>> next) => next(Payload);

        public Task<IResult<TNext>> BindAsync<TNext>(Func<T, Task<IResult<TNext>>> next) => next(Payload);
    }

    public class Success : IResult<Unit>
    {
        public IResult<TNext> Bind<TNext>(Func<Unit, IResult<TNext>> next) => next(new Unit());

        public IResult<TNext> Bind<TNext>(Func<IResult<TNext>> next) => next();

        public Task<IResult<TNext>> BindAsync<TNext>(Func<Unit, Task<IResult<TNext>>> next) => next(new Unit());

        public Task<IResult<TNext>> BindAsync<TNext>(Func<Task<IResult<TNext>>> next) => next();
    }

    public class Failure<T> : Failure, IResult<T>
    {
        public Failure(IError error) : base(error) { }

        public IResult<TNext> Bind<TNext>(Func<T, IResult<TNext>> next) => 
            new Failure<TNext>(Error);

        public Task<IResult<TNext>> BindAsync<TNext>(Func<T, Task<IResult<TNext>>> next) => 
            Task.FromResult<IResult<TNext>>(new Failure<TNext>(Error));
    }

    public class Failure : IResult<Unit>
    {
        public IError Error { get; }

        public Failure(IError error) 
        { 
            if(error is null) throw new ArgumentNullException(nameof(error));

            Error = error; 
        }

        public IResult<TNext> Bind<TNext>(Func<Unit, IResult<TNext>> next) => new Failure<TNext>(Error);

        public IResult<TNext> Bind<TNext>(Func<IResult<TNext>> next) => new Failure<TNext>(Error);

        public Task<IResult<TNext>> BindAsync<TNext>(Func<Unit, Task<IResult<TNext>>> next) =>
            Task.FromResult<IResult<TNext>>(new Failure<TNext>(Error));

        public Task<IResult<TNext>> BindAsync<TNext>(Func<Task<IResult<TNext>>> next) =>
            Task.FromResult<IResult<TNext>>(new Failure<TNext>(Error));
    }

    public interface IError
    {
        string Message { get; }
    }

    public static class AsyncExtensions
    {
        public static async Task<IResult<TNext>> BindAsync<TPrev, TNext>(
            this Task<IResult<TPrev>> prev, Func<IResult<TNext>> next) =>
            (await prev).Bind(next);

        public static async Task<IResult<TNext>> BindAsync<TPrev, TNext>(
            this Task<IResult<TPrev>> prev, Func<TPrev, IResult<TNext>> next) =>
            (await prev).Bind(next);
            
        public static async Task<IResult<TNext>> BindAsync<TPrev, TNext>(
            this Task<IResult<TPrev>> prev, Func<Task<IResult<TNext>>> next) =>
            await (await prev).BindAsync(next);
        public static async Task<IResult<TNext>> BindAsync<TPrev, TNext>(
            this Task<IResult<TPrev>> prev, Func<TPrev, Task<IResult<TNext>>> next) =>
            await (await prev).BindAsync(next);
    }
}