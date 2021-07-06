using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Feree.ResultType.Results
{
    public record Failure<T> : Failure, IResult<T>
    {
        protected internal Failure(IError error) : base(error)
        {
        }

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IResult<TNext> Bind<TNext>(Func<T, IResult<TNext>> next) =>
            new Failure<TNext>(Error);

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Task<IResult<TNext>> BindAsync<TNext>(Func<T, Task<IResult<TNext>>> next) =>
            Task.FromResult<IResult<TNext>>(new Failure<TNext>(Error));
    }

    public abstract record Failure : IResult<Unit>
    {
        public IError Error { get; }

        protected internal Failure(IError error) => Error = error ?? throw new ArgumentNullException(nameof(error));

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IResult<TNext> Bind<TNext>(Func<Unit, IResult<TNext>> next) => new Failure<TNext>(Error);

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IResult<TNext> Bind<TNext>(Func<IResult<TNext>> next) => new Failure<TNext>(Error);

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Task<IResult<TNext>> BindAsync<TNext>(Func<Unit, Task<IResult<TNext>>> next) =>
            Task.FromResult<IResult<TNext>>(new Failure<TNext>(Error));

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Task<IResult<TNext>> BindAsync<TNext>(Func<Task<IResult<TNext>>> next) =>
            Task.FromResult<IResult<TNext>>(new Failure<TNext>(Error));
    }
}