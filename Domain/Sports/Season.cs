using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Sports
{
    public class Season : Entity<SeasonId> //TODO: optional to make it IAggregateRoot??
    {
        public League League { get; protected set; }
        public Range<DateTime> Range { get; protected set; }
        public IReadOnlyDictionary<Team, (Conference Conference, Division Division)> TeamMap => _teamMap;
        private Dictionary<Team, (Conference Conference, Division Division)> _teamMap;

        public IReadOnlyCollection<GameId> GameIds => _gameIds;
        private HashSet<GameId> _gameIds = new HashSet<GameId>();

        private Season() { }
        public static Season New(League league, uint id, Range<DateTime> range)
        {
            return new Season()
            {
                League = league,
                Id = new SeasonId(id),
                Range = range,
            };
        }

        public string AddTeamMap(IEnumerable<(Team Team, Conference Conference, Division Division)> mappings)
        {
            if (mappings == null || mappings.Count() == 0)
                return $"Maps is null or empty";

            
            var divisionConference = new Dictionary<Division, Conference>();
            _teamMap = new Dictionary<Team, (Conference Conference, Division Division)>();

            foreach (var item in mappings)
            {
                //map belongs to this League
                if (!League.Conferences.Contains(item.Conference) || item.Conference.League != League)
                    return $"Conference not found in League: {item.Conference}";

                if (!League.Divisions.Contains(item.Division) || item.Division.League != League)
                    return $"Division not found in League: {item.Division}";

                if (!League.Teams.Contains(item.Team) || item.Team.League != League)
                    return $"Team not found in League: {item.Team}";

                //each division belongs to 1 conference
                if (divisionConference.TryGetValue(item.Division, out Conference match) && match != item.Conference)
                    return $"Division already belongs to a Conference in mapping: {item}";
                divisionConference[item.Division] = item.Conference;

                //team mapping unique
                if (_teamMap.ContainsKey(item.Team))
                    return $"Duplicate Team in mapping: {item.Team}";

                item.Conference.AddToMap(this, item.Division);
                item.Division.AddToMap(this, item.Team);
                _teamMap[item.Team] = (item.Conference, item.Division);
            }
            return null;
        }

        public string AddGame(Game g)
        {
            if (g.SeasonId != Id)
                return $"Game doesn't belong to this season";
            
            if (_gameIds.Contains(g.Id))
                return $"GameId {g.Id} is not unique for this season";

            //must be in the range of the Season
            if (!Range.Contains(g.DatePlayed))
                return $"Game {g.Id} is not in season range";

            if (g.TeamIds.Any(x => !League.Teams.Any(y => y.Id == x)))
                return $"Game's TeamIds:  {string.Join(',', g.TeamIds)} is not in season League Team list";

            _gameIds.Add(g.Id);
            return null;
        }

        public override string ToString()
        {
            return $"SEASON: {Range} for League {League.Name} \r\n GAMES: {string.Join(",", _gameIds)}";
        }
    }

    public class SeasonId : Id
    {
        public SeasonId(uint id) : base(id) { }
    }
}
