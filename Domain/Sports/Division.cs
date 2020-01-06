using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Domain.Sports
{
    public class Division : NameAbbrEntity<DivisionId>
    {
        public League League { get; protected set; }

        public IReadOnlyDictionary<Season, IReadOnlyCollection<Team>> Map => _map.ToDictionary(kvp => kvp.Key, kvp => (IReadOnlyCollection<Team>)kvp.Value);
        private Dictionary<Season, HashSet<Team>> _map = new Dictionary<Season, HashSet<Team>>();

        private Division() { }
        public static Division New(League league, uint id, string name, string abbr)
        {
            return new Division()
            {
                League = league,
                Id = new DivisionId(id),
                Name = name,
                Abbr = abbr,
            };
        }
        public string AddToMap(Season season, Team team)
        {
            if (season == null || team == null)
                return "AddToMap argument is null";

            if (_map.TryGetValue(season, out HashSet<Team> set))
            {
                //false = already present, throw exception??
                set.Add(team);
            }
            else
            {
                _map[season] = new HashSet<Team>() { team };
            }
            return null;
        }

        public override string ToString()
        {
            return $"DIVISION: {Id.Value} {Name} {Abbr}";
        }
    }

    public class DivisionId : Id
    {
        public DivisionId(uint id) : base(id) { }
    }
}
