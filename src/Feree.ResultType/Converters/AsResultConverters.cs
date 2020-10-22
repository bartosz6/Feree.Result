using System.Diagnostics;
using System.Threading.Tasks;
using Feree.ResultType.Factories;
using Feree.ResultType.Results;

namespace Feree.ResultType.Converters
{
    [DebuggerStepThrough]
    public static class AsResultConverters
    {
        public static IResult<T> AsResult<T>(this T @object) => ResultFactory.CreateSuccess(@object);
        public static ValueTask<IResult<T>> AsResultAsync<T>(this T @object) => 
           new ValueTask<IResult<T>>(ResultFactory.CreateSuccess(@object));

        public static async Task<IResult<T>> AsResultAsync<T>(this Task<T> task) => ResultFactory.CreateSuccess(await task);
    }
}