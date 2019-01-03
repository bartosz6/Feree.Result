using System;
using System.Threading.Tasks;
using Feree.ResultType.Errors;

namespace Feree.ResultType.Results
{
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