namespace Domain.Sports
{
    public class Team : NameAbbrEntity<TeamId>
    {
        public League League { get; protected set; }

        private Team() { }
        public static Team New(League league, uint id, string name, string abbr)
        {
            return new Team()
            {
                League = league,
                Id = new TeamId(id),
                Name = name,
                Abbr = abbr,
            };
        }
    }

    public class TeamId : Id
    {
        public TeamId(uint id) : base(id) { }
    }
}
