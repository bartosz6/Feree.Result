using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Feree.ResultType.Errors;
using Feree.ResultType.Results;

namespace Feree.ResultType.Factories
{
    [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
    public static class ResultFactory
    {
        public static IResult<T> CreateSuccess<T>(T payload) =>
            payload is null
                ? CreateFailure<T>($"payload {typeof(T).Name} was null")
                : new Success<T>(payload);

        public static IResult<Unit> CreateSuccess() =>
            new Success<Unit>(new Unit());

        public static IResult<T> CreateFailure<T>(IError error) =>
            error is null
                ? CreateFailure<T>("error was null")
                : new Failure<T>(error);

        public static IResult<Unit> CreateFailure(IError error) =>
            error is null
                ? CreateFailure<Unit>("error was null")
                : new Failure<Unit>(error);

        public static IResult<T> CreateFailure<T>(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0) =>
            message is null
                ? CreateFailure<T>("error message was null")
                : new Failure<T>(new Error(message, memberName, sourceFilePath, sourceLineNumber));

        public static IResult<Unit> CreateFailure(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0) =>
            message is null
                ? CreateFailure<Unit>("error message was null")
                : new Failure<Unit>(new Error(message, memberName, sourceFilePath, sourceLineNumber));

        public static Task<IResult<T>> CreateSuccessAsync<T>(T payload) =>
            Task.FromResult(CreateSuccess(payload));

        public static Task<IResult<Unit>> CreateSuccessAsync() =>
            Task.FromResult(CreateSuccess());

        public static Task<IResult<T>> CreateFailureAsync<T>(IError error) =>
            Task.FromResult(CreateFailure<T>(error));

        public static Task<IResult<Unit>> CreateFailureAsync(IError error) =>
            Task.FromResult(CreateFailure(error));

        public static Task<IResult<T>> CreateFailureAsync<T>(string message) =>
            Task.FromResult(CreateFailure<T>(message));

        public static Task<IResult<Unit>> CreateFailureAsync(string message) =>
            Task.FromResult(CreateFailure(message));
    }
}