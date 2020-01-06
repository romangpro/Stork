namespace Domain
{
    public class NameAbbrEntity<TId> : Entity<TId>
        where TId : Id
    {
        public string Name { get; protected set; }
        public string Abbr { get; protected set; }
    }
}
