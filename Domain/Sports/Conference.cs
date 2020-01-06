using System.Collections.Generic;
using System.Linq;

namespace Domain.Sports
{
    /// <summary>
    /// Conference is high team organization - ie in MLB, NL and AL, or in NHL, Western and Eastern Conference
    /// </summary>
    public class Conference : NameAbbrEntity<ConferenceId>
    {
        public League League { get; protected set; }
        public IReadOnlyDictionary<Season, IReadOnlyCollection<Division>> Map => _map.ToDictionary(kvp => kvp.Key, kvp => (IReadOnlyCollection<Division>)kvp.Value);
        private Dictionary<Season, HashSet<Division>> _map = new Dictionary<Season, HashSet<Division>>();

        private Conference() { }
        public static Conference New(League league, uint id, string name, string abbr)
        {
            return new Conference()
            {
                League = league,
                Id = new ConferenceId(id),
                Name = name,
                Abbr = abbr,
            };
        }

        public string AddToMap(Season season, Division division)
        {
            if (season == null || division == null)
                return "AddToMap argument is null";

            if (_map.TryGetValue(season, out HashSet<Division> set)) 
            {
                set.Add(division);
            }
            else
            {
                _map[season] = new HashSet<Division>() { division };
            }
            return null;
        }

        public override string ToString()
        {
            return $"CONFERENCE: {Id.Value} {Name} {Abbr}";
        }
    }

    public class ConferenceId : Id
    {
        public ConferenceId(uint id) : base(id) { }
    }
}
