using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Feree.ResultType.Errors;
using Feree.ResultType.Results;
using Feree.ResultType.Unit;

namespace Feree.ResultType.Factories
{
    public static class ResultFactory
    {
        public static IResult<T> CreateSuccess<T>(T payload) => 
            new Success<T>(payload);
        
        public static IResult<Empty> CreateSuccess() => 
            new Success<Empty>(new Empty());
        
        public static async Task<IResult<T>> CreateSuccessAsync<T>(Task<T> payload) => 
            new Success<T>(await payload);

        public static IResult<T> CreateFailure<T>(IError error) => 
            new Failure<T>(error);
        
        public static IResult<Empty> CreateFailure(IError error) => 
            new Failure<Empty>(error);

        public static IResult<T> CreateFailure<T>(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0) =>
            new Failure<T>(new Error(message, memberName, sourceFilePath, sourceLineNumber));

        public static IResult<Empty> CreateFailure(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0) =>
            new Failure<Empty>(new Error(message, memberName, sourceFilePath, sourceLineNumber));

        public static async Task<IResult<T>> CreateFailure<T>(Task<IError> error) => 
            new Failure<T>(await error);
        
        public static async Task<IResult<Empty>> CreateFailure(Task<IError> error) => 
            new Failure<Empty>(await error);

        public static async Task<IResult<T>> CreateFailure<T>(Task<string> message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0) =>
            new Failure<T>(new Error(await message, memberName, sourceFilePath, sourceLineNumber));

        public static async Task<IResult<Empty>> CreateFailure(Task<string> message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0) =>
            new Failure<Empty>(new Error(await message, memberName, sourceFilePath, sourceLineNumber));
    }
}