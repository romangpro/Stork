using System;

namespace Domain
{
    /// <summary>
    /// An Entity has unique identity - user1 and user2 both have cart with 1 item - TV, but those carts are different.
    /// Equals: 
    ///     - not null
    ///     - same reference
    ///     - same type
    ///     - same id
    /// </summary>
    /// <typeparam name="IId"></typeparam>
    public abstract class Entity<TId>
        : IEquatable<Entity<TId>> 
        where TId : Id
    {
        public TId Id { get; set; } //TODO: Fix

        public override bool Equals(object obj)
        {
            var entity = obj as Entity<TId>;
            if (entity is null)
                return false;
            if (ReferenceEquals(this, entity))
                return true;
            return Equals(entity);
        }

        public bool Equals(Entity<TId> other)
        {
            return GetType() == other.GetType() && Id.Equals(other.Id);
        }

        public static bool operator ==(Entity<TId> a, Entity<TId> b)
        {
            if (a is null && b is null)
                return true;
            if (a is null || b is null)
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(Entity<TId> a, Entity<TId> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GetType(), Id.GetHashCode());
        }

        public override string ToString()
        {
            return $"ENTITY: {GetType()} {Id.ToString()}";
        }
    }
}
