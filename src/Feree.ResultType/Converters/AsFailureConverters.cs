using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Feree.ResultType.Factories;
using Feree.ResultType.Results;
// ReSharper disable ExplicitCallerInfoArgument

namespace Feree.ResultType.Converters
{
    [DebuggerStepThrough]
    public static class AsFailureConverters
    {
        public static IResult<T> AsFailure<T>(this string errorMessage,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0) => 
            ResultFactory.CreateFailure<T>(errorMessage, memberName, sourceFilePath, sourceLineNumber);
        
        public static IResult<Unit> AsFailure(this string errorMessage,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0) => 
            ResultFactory.CreateFailure(errorMessage, memberName, sourceFilePath, sourceLineNumber);
        
        public static ValueTask<IResult<Unit>> AsFailureAsync(this string errorMessage,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0) => 
        new ValueTask<IResult<Unit>>(errorMessage.AsFailure(memberName, sourceFilePath, sourceLineNumber));
        
        public static ValueTask<IResult<T>> AsFailureAsync<T>(this string errorMessage,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0) => 
        new ValueTask<IResult<T>>(errorMessage.AsFailure<T>(memberName, sourceFilePath, sourceLineNumber));
    }
}