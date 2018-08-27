using System;
using System.Collections.Generic;

namespace Feree.ResultType
{
    public struct Unit : IEqualityComparer<Unit>, IEquatable<Unit>
    {
        public bool Equals(Unit x, Unit y) => true;

        public int GetHashCode(Unit obj) => 0;
        
        public bool Equals(Unit other) => Equals(this, other);

        public override bool Equals(object obj) => !ReferenceEquals(null, obj) && obj is Unit;

        public override int GetHashCode() => GetHashCode(this);
    }
}