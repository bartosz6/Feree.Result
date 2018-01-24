using System;
using System.Collections.Generic;

namespace Feree.ResultType.Results
{
    public struct Success<T> : IResult<T>, IEquatable<IResult<T>>, IEqualityComparer<IResult<T>>
    {
        public Success(T payload)
        {
            Payload = payload != null ? payload : throw new ArgumentNullException(nameof(payload));
        }

        public T Payload { get; }

        public bool Equals(IResult<T> other) => Equals(this, other);
        
        public bool Equals(IResult<T> x, IResult<T> y) => 
            x is Success<T> successX && y is Success<T> successY && successX.Payload.Equals(successY.Payload);

        public int GetHashCode(IResult<T> obj) => obj is Success<T> success ? success.Payload.GetHashCode() : 0;
    }
}