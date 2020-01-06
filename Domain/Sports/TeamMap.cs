using System.Collections.Generic;
using System.Linq;

namespace Domain.Model.Sports
{
    /// <summary>
    /// Conference, Division change : NHL and NBA changed number of Divisions
    /// Options
    /// 1. Slow-Changing Dimension: Conference/Division have "Version" table with arbitrary Effective date
    /// 2. Version by Season: SeasonDivision has set of Teams. Each subsequent season references this single set.
    /// 3. Simplest: duplicate the Conference/Division/Team for each season
    /// 
    /// Duplex linking this mapping is cumbersome with little benefit. 
    /// Primarily use is which Division/Conference was the Team in this season.
    /// </summary>
    //public class TeamMap : ValueObject
    //{
    //    public ConferenceId ConferenceId { get; }
    //    public DivisionId DivisionId { get; }
    //    public TeamId TeamId { get; }

    //    public TeamMap(Conference c, Division d, Team t) : this(c.Id, d.Id, t.Id) { }
    //    public TeamMap(ConferenceId c, DivisionId d, TeamId t)
    //    {
    //        ConferenceId = c; DivisionId = d; TeamId = t;
    //    }
    //    public override IEnumerable<object> Properties => Enumerable.Empty<object>().Append(ConferenceId).Append(DivisionId).Append(TeamId);
    //}
}
