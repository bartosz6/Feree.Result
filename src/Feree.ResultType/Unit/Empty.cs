using System;
using System.Collections.Generic;

namespace Feree.ResultType.Unit
{
    public struct Empty : IEqualityComparer<Empty>, IEquatable<Empty>
    {
        public bool Equals(Empty x, Empty y) => true;

        public int GetHashCode(Empty obj) => 0;
        
        public bool Equals(Empty other) => Equals(this, other);

        public override bool Equals(object obj) => !ReferenceEquals(null, obj) && obj is Empty;

        public override int GetHashCode() => GetHashCode(this);
    }
}