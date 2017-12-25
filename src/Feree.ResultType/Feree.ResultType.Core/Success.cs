using System;

namespace Feree.ResultType.Core
{
    public class Success<T> : IResult<T>
    {
        internal Success(T payload)
        {
            Payload = payload != null ? payload : throw new ArgumentNullException(nameof(payload));
        }

        public T Payload { get; }
    }

    public class Success : Success<Empty>, IResult
    {
        internal Success() : base(new Empty())
        {
        }
    }
}