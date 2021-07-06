using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Feree.ResultType.Factories;
using Feree.ResultType.Results;

namespace Feree.ResultType.Converters
{
    public static class AsFailureConverters
    {
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IResult<T> AsFailure<T>(this string errorMessage,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0) => 
            ResultFactory.CreateFailure<T>(errorMessage, memberName, sourceFilePath, sourceLineNumber);
        
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IResult<Unit> AsFailure(this string errorMessage,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0) => 
            ResultFactory.CreateFailure(errorMessage, memberName, sourceFilePath, sourceLineNumber);
        
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<IResult<Unit>> AsFailureAsync(this string errorMessage,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0) => 
        new(errorMessage.AsFailure(memberName, sourceFilePath, sourceLineNumber));
        
        [DebuggerHidden]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueTask<IResult<T>> AsFailureAsync<T>(this string errorMessage,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0) => 
        new(errorMessage.AsFailure<T>(memberName, sourceFilePath, sourceLineNumber));
    }
}