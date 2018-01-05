using System;

namespace Feree.ResultType
{
    public class Failure<T> : IResult<T>
    {
        internal Failure(IError error)
        {
            Error = error ?? throw new ArgumentNullException(nameof(error));
        }

        public IError Error { get; }
    }

    public class Failure : Failure<Empty>, IResult
    {
        internal Failure(IError error) : base(error)
        {
        }
    }
}