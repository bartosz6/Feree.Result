using System;
using System.Collections.Generic;

namespace Feree.ResultType.Errors
{
    public struct Error : IError, IEqualityComparer<Error>, IEquatable<Error>
    {
        public Error(string message)
        {
            Message = message;
        }

        public string Message { get; }

        public bool Equals(Error x, Error y) => x.Message == y.Message;

        public int GetHashCode(Error obj) => obj.Message?.GetHashCode() ?? 0;

        public bool Equals(Error other) => Equals(this, other);

        public override bool Equals(object obj) => !ReferenceEquals(null, obj) && obj is Error error && Equals(error);

        public override int GetHashCode() => GetHashCode(this);
    }
}