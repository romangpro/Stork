using System.Collections.Generic;
using System.Linq;

namespace Domain.Sports
{
    /// <summary>
    /// NBA, NHL, MLB (not baseball AL/NL)
    /// League  divisions   teams   games/team  games/season    time play   total typical time
    /// MLB     6           30          162         2430            ...         3hr
    /// NBA     6           30          82          1230            4x12min     2hr
    /// NHL     4           31          82          1271            3x20min     2.5hr
    /// NFL     4           32          16          256             ...         3hr
    /// </summary>
    /// League is aggregate root to enforce invariants on dependencies: Conference, Division, Team, Season
    /// 
 /*
ex: NBA
Eastern and Western Conferences
Atlantic, Central, SouthEast    NorthWest, Pacific, SouthWest

*/
    public class League : NameAbbrEntity<LeagueId>, IAggregateRoot
    {
        public Sex Sex { get; private set; }
        public Sport Sport { get; private set; }
        public LeagueLocation LeagueLocation { get; private set; }
        public IReadOnlyList<Season> Seasons => _seasons.AsReadOnly();
        private List<Season> _seasons = new List<Season>();
        public IReadOnlyList<Conference> Conferences => _conferences.AsReadOnly();
        private List<Conference> _conferences = new List<Conference>();
        public IReadOnlyList<Division> Divisions => _divisions.AsReadOnly();
        private List<Division> _divisions = new List<Division>();
        public IReadOnlyList<Team> Teams => _teams.AsReadOnly();
        private List<Team> _teams = new List<Team>();

        private League() { }
        public static League New(uint id, string name, string abbr, Sex sex, Sport sport, LeagueLocation location)
        {
            return new League()
            {
                Id = new LeagueId(id),
                Name = name,
                Abbr = abbr,
                Sex = sex,
                Sport = sport,
                LeagueLocation = location,
            };
        }

        public string AddSeason(Season season)
        {
            if (season.League != this)
            {
                return $"Season doesn't belong to this League";
            }
            if (Seasons.Any(x => x.Range.Contains(season.Range)))
            {
                return $"Season overlaps existing seasons: {season.ToString()}";
            }
            _seasons.Add(season);
            return null;
        }

        public string AddConference(Conference conference)
        {
            if (conference.League != this)
            {
                return $"Conference doesn't belong to this League";
            }
            if (Conferences.Any(x => x.Name == conference.Name || x.Abbr == conference.Abbr))
            {
                return $"Conference name or abbr must be unique: {conference.ToString()}";
            }
            _conferences.Add(conference);
            return null;
        }

        public string AddDivision(Division division)
        {
            if (division.League != this)
            {
                return $"Division doesn't belong to this League";
            }
            if (Divisions.Any(x => x.Name == division.Name || x.Abbr == division.Abbr))
            {
                return $"Divison name or abbr must be unique: {division.ToString()}";
            }
            _divisions.Add(division);
            return null;
        }

        public string AddTeam(Team team)
        {
            if (team.League != this)
            {
                return $"Team doesn't belong to this League";
            }
            if (Teams.Any(x => x.Name == team.Name || x.Abbr == team.Abbr))
            {
                return $"Team name or abbr must be unique: {team.ToString()}";
            }
            _teams.Add(team);
            return null;
        }

        public override string ToString()
        {
            return $"LEAGUE: {Id} {Name} {Abbr} {Sex} {Sport} {LeagueLocation} \r\n " +
                $"SEASONS: {string.Join("\r\n", Seasons)} \r\n " +
                $"CONFERENCES: {string.Join("\r\n", Conferences)} \r\n " +
                $"TEAMS: {string.Join("\r\n", Teams)}";
        }
    }

    public class LeagueId : Id
    {
        public LeagueId(uint id) : base(id) { }
    }
}

