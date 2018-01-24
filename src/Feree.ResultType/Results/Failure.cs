using System;
using System.Collections.Generic;
using Feree.ResultType.Errors;

namespace Feree.ResultType.Results
{
    public struct Failure<T> : IResult<T>, IEquatable<IResult<T>>, IEqualityComparer<IResult<T>>
    {
        public Failure(IError error)
        {
            Error = error ?? throw new ArgumentNullException(nameof(error));
        }

        public IError Error { get; }

        public bool Equals(IResult<T> other) => Equals(this, other);
        
        public bool Equals(IResult<T> x, IResult<T> y) => 
            x is Failure<T> failureX && y is Failure<T> failureY && failureX.Error.Equals(failureY.Error);

        public int GetHashCode(IResult<T> obj) => obj is Failure<T> failure ? failure.Error.GetHashCode() : 0;
    }
}