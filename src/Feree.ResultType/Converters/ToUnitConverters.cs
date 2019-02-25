using System.Threading.Tasks;
using Feree.ResultType.Factories;
using Feree.ResultType.Results;

namespace Feree.ResultType.Converters
{
    public static class ToUnitConverters
    {
        public static IResult<Unit> ToUnit<T>(this IResult<T> result) => result.Bind(_ => ResultFactory.CreateSuccess());
        public static Task<IResult<Unit>> ToUnitAsync<T>(this Task<IResult<T>> result) => result.BindAsync(_ => ResultFactory.CreateSuccess());
    }
}