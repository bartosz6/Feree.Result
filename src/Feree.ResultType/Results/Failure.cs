using System;
using Feree.ResultType.Errors;
using Feree.ResultType.Unit;

namespace Feree.ResultType.Results
{
    public class Failure<T> : IResult<T>
    {
        internal Failure(IError error)
        {
            Error = error ?? throw new ArgumentNullException(nameof(error));
        }

        public IError Error { get; }
    }

    public class Failure : Failure<Empty>
    {
        internal Failure(IError error) : base(error)
        {
        }
    }
}