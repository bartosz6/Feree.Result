using System;
using System.Threading.Tasks;
using Feree.ResultType.Converters;
using Feree.ResultType.Results;

namespace Feree.ResultType.Operations
{
    public static class BindToAnyExtensions
    {
        public static Task<IResult<TNext>> BindAnyAsync<TPrev, TNext>(this Task<IResult<TPrev>> prev, Func<TNext> next) =>
            prev.BindAsync(() => next().AsResult());

        public static Task<IResult<TNext>> BindAnyAsync<TPrev, TNext>(this Task<IResult<TPrev>> prev, Func<Task<TNext>> next) =>
            prev.BindAsync(() => next().AsResultAsync());

        public static Task<IResult<TNext>> BindAnyAsync<TPrev, TNext>(this IResult<TPrev> prev, Func<Task<TNext>> next) =>
            prev.BindAsync(() => next().AsResultAsync());

        public static IResult<TNext> BindAny<TPrev, TNext>(this IResult<TPrev> prev, Func<TNext> next) =>
            prev.Bind(() => next().AsResult());
    }
}