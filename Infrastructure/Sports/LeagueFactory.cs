using Domain;
using System;
using System.Linq;

namespace Infrastructure.Sports
{
    public static class LeagueFactory
    {
        private static readonly DateTime START = new DateTime(2010, 1, 1);
        private static Range<DateTime> YEAR(int n)
        {
            return new Range<DateTime>(START.AddYears(n), START.AddYears(n + 1).AddDays(-1));
        }

        public static LeagueDao NewLeague(int N)
        {
            var l = new LeagueDao() { Name = $"{N}", Abbr = $"{N}", Sex = 1, Sport = 1, LeagueLocation = 7 };
            l.Conferences = Enumerable.Range(1, N).Select((x, i) => new ConferenceDao() { Name = $"{N}_{i}" }).ToArray();
            l.Divisions = Enumerable.Range(1, N).Select((x, i) => new DivisionDao() { Name = $"{N}_{i}" }).ToArray();
            l.Teams = Enumerable.Range(1, N).Select((x, i) => new TeamDao() { Name = $"{N}_{i}" }).ToArray();
            //l.Seasons = Enumerable.Range(1, N).Select((x, i) => SeasonDao.Create(YEAR(i))
            //{
            //    TeamMaps = new[] {
            //        new TeamMap() { Conference=l.Conferences.First(), Division =l.Divisions.First(), Team=l.Teams.First() } }
            //}).ToArray();
            return l;
        }
    }
}
