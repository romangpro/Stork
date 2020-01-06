using System;

namespace Domain.Sports
{
    public class LeagueFactory// : ILeagueFactory
    {
        //private static uint Num { get; set; } = 0;
        //public League NewLeague(CreateLeagueCommand cmd)
        //{
        //    Num++;
        //    return new League(Num, cmd.Name, cmd.Abbr, cmd.Sex, cmd.Sport, cmd.LeagueLocation);
        //}

        public static League NBA(uint x)
        {
            return League.New(x, "National Basketball Association", "NBA", Sex.Men, Sport.Basketball, LeagueLocation.CanadaUSA);
        }

        public static League NHL(uint x)
        {
            return League.New(x, "National Hockey League", "NHL", Sex.Men, Sport.Hockey, LeagueLocation.CanadaUSA);
        }

        public static League MLB(uint x)
        {
            return League.New(x, "Major League Baseball", "MLB", Sex.Men, Sport.Baseball, LeagueLocation.CanadaUSA);
        }

        public static League WNBA(uint x)
        {
            return League.New(x, "Women's National Basketball Association", "WNBA", Sex.Women, Sport.Basketball, LeagueLocation.USA);
        }

        public static League NBA_WithNChildren(uint x, uint N)
        {
            var l = NBA(x);
            for (uint n = 0; n < N; n++)
            {
                var c = Conference.New(l, n, "a" + n, "a" + n);
                var d = Division.New(l, n, "a" + n, "a" + n);
                var t = Team.New(l, n, "a" + n, "a" + n);
                var s = Season.New(l, n, _Year((int)n));
                l.AddConference(c);
                l.AddDivision(d);
                l.AddTeam(t);
                l.AddSeason(s);
            }
            return l;
        }

        public static Range<DateTime> _Year(int n)
        {
            var start = new DateTime(2010, 1, 1);
            return new Range<DateTime>(start.AddYears(n), start.AddYears(n + 1).AddDays(-1));
        }
    }
}
