using System;

namespace Feree.ResultType.Core
{
    public class Failure<T> : IResult<T>
    {
        public Failure(IError error)
        {
            Error = error ?? throw new ArgumentNullException(nameof(error));
        }

        public IError Error { get; }
    }

    public class Failure : Failure<Empty>, IResult
    {
        public Failure(IError error) : base(error)
        {
        }
    }
}