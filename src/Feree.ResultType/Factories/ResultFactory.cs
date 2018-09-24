using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Feree.ResultType.Errors;
using Feree.ResultType.Results;

namespace Feree.ResultType.Factories
{
    [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
    public static class ResultFactory
    {
        public static IResult<T> CreateSuccess<T>(T payload) => 
            new Success<T>(payload);
        
        public static IResult<Unit> CreateSuccess() => 
            new Success<Unit>(new Unit());
        
        public static IResult<T> CreateFailure<T>(IError error) => 
            new Failure<T>(error);
        
        public static IResult<Unit> CreateFailure(IError error) => 
            new Failure<Unit>(error);

        public static IResult<T> CreateFailure<T>(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0) =>
            new Failure<T>(new Error(message, memberName, sourceFilePath, sourceLineNumber));

        public static IResult<Unit> CreateFailure(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0) =>
            new Failure<Unit>(new Error(message, memberName, sourceFilePath, sourceLineNumber));
    }
}