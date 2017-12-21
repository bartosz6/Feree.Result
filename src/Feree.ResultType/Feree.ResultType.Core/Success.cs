namespace Feree.ResultType.Core
{
    public class Success<T> : IResult<T>
    {
        internal Success(T payload)
        {
            Payload = payload;
        }

        public T Payload { get; }
    }
}