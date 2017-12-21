namespace Feree.ResultType.Core
{
    public static class ResultFactory
    {
        public static Success<T> CreateSuccess<T>(T payload) => new Success<T>(payload);
        public static Success<Empty> CreateSuccess() => new Success<Empty>(new Empty());
        
        public static Failure<T> CreateFailure<T>(IError error) => new Failure<T>(error);
        public static Failure<T> CreateFailure<T>(string message) => new Failure<T>(new Error(message));
        public static Failure<Empty> CreateFailure(IError error) => new Failure<Empty>(error);
        public static Failure<Empty> CreateFailure(string message) => new Failure<Empty>(new Error(message));
    }
}