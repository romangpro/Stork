using System;

namespace Domain
{
    public class VersionedEntity<TId> : Entity<TId> 
        where TId : Id
    {
        public DateTime Effective { get; protected set; } 
    }
}
