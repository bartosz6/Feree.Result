using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Feree.ResultType.Factories;
using Feree.ResultType.Results;

namespace Feree.ResultType.Converters
{
    public static class AsResultConverters
    {
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IResult<T> AsResult<T>(this T @object) => ResultFactory.CreateSuccess(@object);
       
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<IResult<T>> AsResultAsync<T>(this T @object) => 
           new ValueTask<IResult<T>>(ResultFactory.CreateSuccess(@object));

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async Task<IResult<T>> AsResultAsync<T>(this Task<T> task) => ResultFactory.CreateSuccess(await task);
    }
}