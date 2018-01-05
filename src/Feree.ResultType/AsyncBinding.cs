using System;
using System.Threading.Tasks;

namespace Feree.ResultType
{
    public static class AsyncBinding
    {
        public static async Task<IResult<TOut>> BindAsync<TIn, TOut>(this IResult<TIn> source, Func<Task<IResult<TOut>>> next)
        {
            switch (source)
            {
                case Success<TIn> _:
                    return await next();
                case Failure<TIn> failure:
                    return new Failure<TOut>(failure.Error);
                default:
                    throw new InvalidOperationException();
            }
        }
        
        public static async Task<IResult<TOut>> BindAsync<TIn, TOut>(this Task<IResult<TIn>> source, Func<Task<IResult<TOut>>> next) => 
            await (await source).BindAsync(async () => await next());

        public static async Task<IResult<TOut>> BindAsync<TIn, TOut>(this Task<IResult<TIn>> source, Func<IResult<TOut>> next) => 
            (await source).Bind(next);

        public static Task<IResult<TOut>> BindAsync<TIn, TOut>(this IResult<TIn> source, Func<TIn, Task<IResult<TOut>>> next) => 
            source.BindAsync(() => next(((Success<TIn>) source).Payload));
        
        public static Task<IResult<TOut>> BindAsync<TIn, TOut>(this Task<IResult<TIn>> source, Func<TIn, Task<IResult<TOut>>> next) => 
            source.BindAsync(async () => await next(((Success<TIn>) await source).Payload));
        
        public static Task<IResult<TOut>> BindAsync<TIn, TOut>(this Task<IResult<TIn>> source, Func<TIn, IResult<TOut>> next) => 
            source.BindAsync(async () => next(((Success<TIn>) await source).Payload));
    }
}