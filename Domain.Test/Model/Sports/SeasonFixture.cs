using Domain.Sports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Test.Model.Sports
{
    [TestFixture]
    public class SeasonFixture
    {
        public static League L1 = LeagueFactory.NBA_WithNChildren(1, 2);
        public static League L2 = LeagueFactory.NBA_WithNChildren(2, 2);

        [TestCaseSource(nameof(AddTeamMap_TestCases))]
        public bool AddTeamMap(IEnumerable<(Team Team, Conference Conference, Division Division)> mappings)
        {
            return L1.Seasons[0].AddTeamMap(mappings) == null;
        }

        public static IEnumerable<TestCaseData> AddTeamMap_TestCases()
        {
            string s = "{m}_";
            yield return new TestCaseData(null).SetName(s + "NullMappings").Returns(false);
            yield return new TestCaseData(Enumerable.Empty<(Team Team, Conference Conference, Division Division)>())
                                                .SetName(s + "EmptyMappings").Returns(false);

            yield return new TestCaseData(new[] { (L1.Teams[0], L2.Conferences[0], L1.Divisions[0]) })
                                                .SetName(s + "ConferenceNotFromLeague").Returns(false);
            yield return new TestCaseData(new[] { (L1.Teams[0], L1.Conferences[0], L2.Divisions[0]) })
                                                .SetName(s + "DivisionNotFromLeague").Returns(false);
            yield return new TestCaseData(new[] { (L2.Teams[0], L1.Conferences[0], L1.Divisions[0]) })
                                                .SetName(s + "TeamNotFromLeague").Returns(false);

            yield return new TestCaseData(new[] { (L1.Teams[0], L1.Conferences[0], L1.Divisions[0]),
                                                  (L1.Teams[1], L2.Conferences[0], L1.Divisions[0]) })
                                                .SetName(s + "DivisionInMultipleConference").Returns(false);
            yield return new TestCaseData(new[] { (L1.Teams[0], L1.Conferences[0], L1.Divisions[0]) ,
                                                  (L1.Teams[0], L1.Conferences[0], L1.Divisions[0]) })
                                                .SetName(s + "TeamNotDistinct").Returns(false);

            yield return new TestCaseData(new[] { (L1.Teams[0], L1.Conferences[0], L1.Divisions[0]),
                                                  (L1.Teams[1], L1.Conferences[1], L1.Divisions[1]) })
                                                .SetName(s + "Valid").Returns(true);
        }

        [TestCaseSource(nameof(AddGame_TestCases))]
        public bool AddGame(Game g)
        {
            return L1.Seasons[0].AddGame(g) == null;
        }

        public static IEnumerable<TestCaseData> AddGame_TestCases()
        {
            string s = "{m}_";
            var d1 = L1.Seasons[0].Range.From;
            var g0 = Game.New((uint)L1.Seasons[1].Id, 1, (uint)L1.Id, d1.AddDays(3), GameType.PreSeason, new[] { L1.Teams[0].Id, L1.Teams[1].Id });
            yield return new TestCaseData(g0).SetName(s + "GameNotFromSeason").Returns(false);
            var g1 = Game.New((uint)L1.Seasons[0].Id, 2, (uint)L1.Id, d1.AddDays(3), GameType.PreSeason, new[] { L1.Teams[0].Id, L1.Teams[1].Id });
            yield return new TestCaseData(g1).SetName(s + "Valid").Returns(true);
            //var g2 = new Game((uint)L1.Seasons[0].Id, 2, (uint)L1.Id, d1.AddDays(4), GameType.PreSeason, new[] { L1.Teams[0].Id, L1.Teams[1].Id });
            yield return new TestCaseData(g1).SetName(s + "GameIsNotUnique").Returns(false);
            var g3 = Game.New((uint)L1.Seasons[0].Id, 4, (uint)L1.Id, d1.AddDays(-4), GameType.PreSeason, new[] { L1.Teams[0].Id, L1.Teams[1].Id });
            yield return new TestCaseData(g3).SetName(s + "NotInSeasonRange").Returns(false);
            var g4 = Game.New((uint)L1.Seasons[0].Id, 5, (uint)L1.Id, d1.AddDays(4), GameType.PreSeason, new[] { new TeamId(999) });
            yield return new TestCaseData(g4).SetName(s + "TeamsNotInSeasonLeague").Returns(false);
        }
    }
}
