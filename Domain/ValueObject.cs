using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Domain
{
    /// <summary>
    /// ValueObject has no unique "Id" like Entity, and is used to model an attribute
    /// ex: for equality.
    /// They are same if all the fields/properties are same
    /// https://impelx.com/ Steven Roberts
    /// </summary>
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public abstract IEnumerable<object> Properties { get; }

        public override bool Equals(object obj)
        {
            return !(obj is null) && (ReferenceEquals(this, obj) || (obj is ValueObject vo && Equals(vo)));
        }

        public bool Equals([NotNull] ValueObject other)
        {
            //will this work if the property is a collection??
            return !(other is null) && GetType() == other.GetType() && Properties.SequenceEqual(other.Properties);
        }

        public static bool operator ==(ValueObject a, ValueObject b)
        {
            if (a is null && b is null)
                return true;
            if (a is null || b is null)
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(ValueObject a, ValueObject b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            var h = new HashCode();
            foreach (var o in Properties)
            {
                h.Add(o);
            }
            return h.ToHashCode();
        }

        public override string ToString()
        {
            return $"VALUEOBJECT: {GetType().Name} {string.Join(",", Properties)}";
        }
    }
}



//    public abstract class Id<T> : IValueObject<T> 
//        where T : struct, IComparable<T>
//    {
//        public override bool Equals(object obj)
//        {
//            if (obj !=null && GetType() == obj.GetType()) //obj is Id<T> id)
//            {
//                return Equals(obj as Id<T>);
//            }
//            return false;
//        }

//        public bool Equals([AllowNull] IValueObject<T> other)
//        {
//            throw new NotImplementedException();
//        }

//        public override int GetHashCode()
//        {
//            throw new NotImplementedException();
//        }

//        //public bool Equals([AllowNull] Id<T> other)
//        //{
//        //    return other != null &&  ReferenceEquals(this, other) || is LeagueId lid && Value == lid.Value;
//        //}

//        //public override int GetHashCode()
//        //{
//        //    throw new NotImplementedException();
//        //}

//        //public static bool operator ==(LeagueId left, LeagueId right)
//        //{
//        //    return left.Equals(right);S
//        //}

//        //public static bool operator !=(LeagueId left, LeagueId right)
//        //{
//        //    return !(left == right);
//        //}


//    }


//    //public override bool Equals(object obj)
//    //{
//    //    var valueObject = obj as T;

//    //    if (ReferenceEquals(valueObject, null))
//    //        return false;

//    //    if (GetType() != obj.GetType())
//    //        return false;

//    //    return EqualsCore(valueObject);
//    //}

//    //protected abstract bool EqualsCore(T other);

//    //public override int GetHashCode()
//    //{
//    //    return GetHashCodeCore();
//    //}

//    //protected abstract int GetHashCodeCore();

//    //public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
//    //{
//    //    if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
//    //        return true;

//    //    if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
//    //        return false;

//    //    return a.Equals(b);
//    //}

//    //public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
//    //{
//    //    return !(a == b);
//    //}
//}
