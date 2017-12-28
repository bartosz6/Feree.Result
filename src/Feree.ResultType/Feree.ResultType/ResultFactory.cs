using System.Threading.Tasks;

namespace Feree.ResultType
{
    public static class ResultFactory
    {
        public static IResult<T> CreateSuccess<T>(T payload) => new Success<T>(payload);
        public static IResult CreateSuccess() => new Success();
        
        public static IResult<T> CreateFailure<T>(IError error) => new Failure<T>(error);
        public static IResult<T> CreateFailure<T>(string message) => new Failure<T>(new Error(message));
        public static IResult CreateFailure(IError error) => new Failure(error);
        public static IResult CreateFailure(string message) => new Failure(new Error(message));
        
        public static async Task<IResult<T>> CreateSuccessAsync<T>(Task<T> payload) => new Success<T>(await payload);
        
        public static async Task<IResult<T>> CreateFailure<T>(Task<IError> error) => new Failure<T>(await error);
        public static async Task<IResult<T>> CreateFailure<T>(Task<string> message) => new Failure<T>(new Error(await message));
        public static async Task<IResult> CreateFailure(Task<IError> error) => new Failure(await error);
        public static async Task<IResult> CreateFailure(Task<string> message) => new Failure(new Error(await message));
    }
}