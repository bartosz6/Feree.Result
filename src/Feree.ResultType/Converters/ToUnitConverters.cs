using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Feree.ResultType.Factories;
using Feree.ResultType.Results;

namespace Feree.ResultType.Converters
{
    public static class ToUnitConverters
    {
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IResult<Unit> ToUnit<T>(this IResult<T> result) => result.Bind(_ => ResultFactory.CreateSuccess());

        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<IResult<Unit>> ToUnitAsync<T>(this Task<IResult<T>> result) => result.BindAsync(_ => ResultFactory.CreateSuccess());
    }
}