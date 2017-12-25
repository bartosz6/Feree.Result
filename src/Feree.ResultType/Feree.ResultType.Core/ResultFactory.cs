namespace Feree.ResultType.Core
{
    public static class ResultFactory
    {
        public static IResult<T> CreateSuccess<T>(T payload) => new Success<T>(payload);
        public static IResult CreateSuccess() => new Success();
        
        public static IResult<T> CreateFailure<T>(IError error) => new Failure<T>(error);
        public static IResult<T> CreateFailure<T>(string message) => new Failure<T>(new Error(message));
        public static IResult CreateFailure(IError error) => new Failure(error);
        public static IResult CreateFailure(string message) => new Failure(new Error(message));
    }
}