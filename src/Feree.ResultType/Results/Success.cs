using System;
using Feree.ResultType.Unit;

namespace Feree.ResultType.Results
{
    public class Success<T> : IResult<T>
    {
        internal Success(T payload)
        {
            Payload = payload != null ? payload : throw new ArgumentNullException(nameof(payload));
        }

        public T Payload { get; }
    }

    public class Success : Success<Empty>
    {
        internal Success() : base(new Empty())
        {
        }
    }
}