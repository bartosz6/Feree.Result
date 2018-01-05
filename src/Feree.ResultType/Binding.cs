using System;

namespace Feree.ResultType
{
    public static class Binding
    {
        public static IResult<TOut> Bind<TIn, TOut>(this IResult<TIn> source, Func<IResult<TOut>> next)
        {
            switch (source)
            {
                case Success<TIn> _:
                    return next();
                case Failure<TIn> failure:
                    return new Failure<TOut>(failure.Error);
                default:
                    throw new InvalidOperationException();
            }
        }

        public static IResult<TOut> Bind<TIn, TOut>(this IResult<TIn> source, Func<TIn, IResult<TOut>> next) => 
            source.Bind(() => next(((Success<TIn>) source).Payload));
    }
}