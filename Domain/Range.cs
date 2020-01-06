using System;

namespace Domain
{
    public interface IRange<T>
    {
        T From { get; }
        T To { get; }
        bool Contains(T t);
        bool Contains(IRange<T> t);
        bool Overlaps(IRange<T> t);
    }

    //It is a "valueobject", but its struct because we dont need the inheritence functionality
    public readonly struct Range<T> : IRange<T> 
        where T : struct, IComparable<T>
    {
        public T From { get; }
        public T To { get; }

        public Range(T from, T to)
        {
            From = from;
            To = to;
            if (To.CompareTo(From) == -1)
                throw new ArgumentOutOfRangeException("invalid range");
        }

        public bool Contains(T t)
        {
            return From.CompareTo(t) <= 0 && To.CompareTo(t) > 0;
        }

        public bool Contains(IRange<T> other)
        {
            return From.CompareTo(other.From) <= 0 && To.CompareTo(other.To) >= 0;
        }

        public bool Overlaps(IRange<T> other)
        {
            return From.CompareTo(other.To) == -1 && To.CompareTo(other.From) == 1;
        }

        public Range<uint> Intersect(Range<uint> other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"RANGE: {From} - {To}";
        }

        public override bool Equals(object obj)
        {
            return obj != null && obj is Range<T> r && From.Equals(r.From) && To.Equals(r.To);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(From, To);
        }

        public static bool operator ==(Range<T> left, Range<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Range<T> left, Range<T> right)
        {
            return !(left == right);
        }
    }
}
