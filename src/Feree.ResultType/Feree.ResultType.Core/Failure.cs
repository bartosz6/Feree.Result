namespace Feree.ResultType.Core
{
    public class Failure<T> : IResult<T>
    {
        public Failure(IError error)
        {
            Error = error;
        }

        public IError Error { get; }
    }
}